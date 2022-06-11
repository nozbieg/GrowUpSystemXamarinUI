using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GrowUpSystemUI.Models;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Xamarin.Forms;

namespace GrowUpSystemUI.Services
{
    class MqttDataService : IMqttDataService
    {
        IMqttClient _client;
        static IMqttClientOptions _options;

        public MqttDataService()
        {
            Debug.WriteLine($"\n\n in MqttDataService constructor \n\n");
        }

        public async Task Initialize()
        {
            Debug.WriteLine($"\n\n in MqttDataService Initialize() \n\n");

            string clientId = string.Empty;
            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    clientId = "GrowUpSystemUIuwp";
                    break;
                case Device.Android:
                    clientId = $"GrowUpSystemUIAndroid_{Guid.NewGuid()}";
                    break;
                default:
                    clientId = "GrowUpSystemUIios";
                    break;
            }

            try
            {
                var factory = new MqttFactory();
                _client = factory.CreateMqttClient();


                _options = new MqttClientOptionsBuilder()
                    .WithClientId(clientId)
                    .WithTcpServer("broker.hivemq.com", 1883)
                    .WithCleanSession(true)
                    .Build();


                IList<Task> tasklist = new List<Task>();
                await _client.ConnectAsync(_options);

                tasklist.Add(_client.SubscribeAsync("GrowUpSystemUI_TemperatureChanged"));
                tasklist.Add(_client.SubscribeAsync("GrowUpSystemUI_HumidityChanged"));
                tasklist.Add(_client.SubscribeAsync("GrowUpSystemUI_MoistOneChanged"));
                tasklist.Add(_client.SubscribeAsync("GrowUpSystemUI_MoistTwoChanged"));
                tasklist.Add(_client.SubscribeAsync("GrowUpSystemUI_MoistThreeChanged"));
                tasklist.Add(_client.SubscribeAsync("GrowUpSystemUI_MoistFourChanged"));

                await Task.WhenAll(tasklist);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            _client.UseConnectedHandler(async e =>
            {
                Debug.WriteLine("Connected successfully with MQTT Brokers.");
                await _client.SubscribeAsync("GrowUpSystemUI");
            });

            _client.UseDisconnectedHandler(async e =>
            {
                Debug.WriteLine("\nDisconnect\n");
                await Task.Delay(TimeSpan.FromSeconds(5));

                try
                {
                    await _client.ConnectAsync(_options, CancellationToken.None); // Since 3.0.5 with CancellationToken
                    Debug.WriteLine("### Reconnection Success! ###");
                    await _client.SubscribeAsync("GrowUpSystemUI");
                }
                catch
                {
                    Debug.WriteLine("### RECONNECTING FAILED ###");
                }
            });

            _client.UseApplicationMessageReceivedHandler(e =>
            {
                MqttMessageTransport mmt = new MqttMessageTransport
                {
                    Topic = e.ApplicationMessage.Topic,
                    Message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                };
                Debug.WriteLine($"Message received in MqttDataService _client_MqttMsgPublishReceived {mmt.Message}");
                mmt.Handle();
            });
        }

        public async Task PublishMqttMessageAsync(string publishmessage, string topic)
        {
            var message = new MqttApplicationMessageBuilder()
                 .WithTopic(topic)
                 .WithPayload(publishmessage)
                 .WithExactlyOnceQoS()
                 .WithRetainFlag()
                 .Build();

            await _client.PublishAsync(message, CancellationToken.None); // Since 3.0.5 with CancellationToken
        }
    }
}
