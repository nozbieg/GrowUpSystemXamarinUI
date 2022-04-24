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
                    MessagingCenter.Send(this, "TemperatureChanged", Message);
                    break;
                case "GrowUpSystemUI_HumidityChanged":
                    MessagingCenter.Send(this, "HumidityChanged", Message);
                    break;
                case "GrowUpSystemUI_MoistOneChanged":
                    MessagingCenter.Send(this, "MoistChanged_One", Message);
                    break;
                case "GrowUpSystemUI_MoistTwoChanged":
                    MessagingCenter.Send(this, "MoistChanged_Two", Message);
                    break;
                case "GrowUpSystemUI_MoistThreeChanged":
                    MessagingCenter.Send(this, "MoistChanged_Three", Message);
                    break;
                case "GrowUpSystemUI_MoistTFourChanged":
                    MessagingCenter.Send(this, "MoistChanged_Four", Message);
                    break;
            }
            Debug.WriteLine($"MessageHandled: \n {Topic} \n {Message}");
        }
    }
}
