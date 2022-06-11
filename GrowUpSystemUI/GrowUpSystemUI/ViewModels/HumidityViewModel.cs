using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GrowUpSystemUI.Models;
using Xamarin.Forms;

namespace GrowUpSystemUI.ViewModels
{
    public class HumidityViewModel : INotifyPropertyChanged
    {


        public HumidityViewModel()
        {
            MoistSensor_One = "Not initialized";
            MoistSensor_Two = "Not initialized";
            MoistSensor_Three = "Not initialized";
            MoistSensor_Four = "Not initialized";
            MessageSubscribe();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        void MessageSubscribe()
        {
            MessagingCenter.Subscribe<MqttMessageTransport, string>(this, "MoistChanged_One", (sender, args) =>
            {
                MoistSensor_One = args;
            });
            MessagingCenter.Subscribe<MqttMessageTransport, string>(this, "MoistChanged_Two", (sender, args) =>
            {
                MoistSensor_Two = args;
            });
            MessagingCenter.Subscribe<MqttMessageTransport, string>(this, "MoistChanged_Three", (sender, args) =>
            {
                MoistSensor_Three = args;
            });
            MessagingCenter.Subscribe<MqttMessageTransport, string>(this, "MoistChanged_Four", (sender, args) =>
            {
                MoistSensor_Four = args;
            });
        }

        string moistSensor_One;
        public string MoistSensor_One
        {
            get { return $"{moistSensor_One}%"; }
            set
            {
                if (moistSensor_One != value)
                {
                    moistSensor_One = value;
                    OnPropertyChanged(nameof(MoistSensor_One));
                }

            }
        }
        string moistSensor_Two;
        public string MoistSensor_Two
        {
            get { return $"{moistSensor_Two}%"; }
            set
            {
                if (moistSensor_Two != value)
                {
                    moistSensor_Two = value;
                    OnPropertyChanged(nameof(MoistSensor_Two));
                }

            }
        }
        string moistSensor_Three;
        public string MoistSensor_Three
        {
            get { return $"{moistSensor_Three}%"; }
            set
            {
                if (moistSensor_Three != value)
                {
                    moistSensor_Three = value;
                    OnPropertyChanged(nameof(MoistSensor_Three));
                }

            }
        }
        string moistSensor_Four;
        public string MoistSensor_Four
        {
            get { return $"{moistSensor_Four}%"; }
            set
            {
                if (moistSensor_Four != value)
                {
                    moistSensor_Four = value;
                    OnPropertyChanged(nameof(MoistSensor_Four));
                }

            }
        }
    }
}
