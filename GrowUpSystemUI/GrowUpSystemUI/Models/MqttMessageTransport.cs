using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace GrowUpSystemUI.Models
{
    public class MqttMessageTransport
    {
        public string Topic { get; set; }
        public string Message { get; set; }


        public void Handle()
        {
            switch (Topic)
            {
                case "GrowUpSystemUI_TemperatureChanged":
                    MessagingCenter.Send<MqttMessageTransport, string>(this, "TemperatureChanged", Message);
                    break;
                case "GrowUpSystemUI_HumidityChanged":
                    MessagingCenter.Send<MqttMessageTransport, string>(this, "HumidityChanged", Message);
                    break;
            }
            Debug.WriteLine($"MessageHandled: \n {Topic} \n {Message}");
        }
    }
}
