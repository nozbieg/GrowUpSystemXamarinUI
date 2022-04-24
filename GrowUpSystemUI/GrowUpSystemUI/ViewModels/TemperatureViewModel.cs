using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GrowUpSystemUI.Models;
using Xamarin.Forms;

namespace GrowUpSystemUI.ViewModels
{
    public class TemperatureViewModel : INotifyPropertyChanged
    {


        string temperature;
        public string Temperature
        {
            get { return temperature; }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                    OnPropertyChanged(nameof(Temperature));
                }

            }
        }

        string humidity;
        public string Humidity
        {
            get { return humidity; }
            set
            {
                if (humidity != value)
                {
                    humidity = value;
                    OnPropertyChanged(nameof(Humidity));
                }

            }
        }


        public TemperatureViewModel()
        {
            MessagingCenter.Subscribe<MqttMessageTransport, string>(this, "TemperatureChanged", (sender, args) =>
            {
                Temperature = args;
            });
            MessagingCenter.Subscribe<MqttMessageTransport, string>(this, "HumidityChanged", (sender, args) =>
            {
                Humidity = args;
            });

            Temperature = "19";
            Humidity = "60";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
