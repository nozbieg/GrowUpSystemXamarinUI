using System;
using GrowUpSystemUI.Services;
using Prism.Events;
using Xamarin.Forms;

namespace GrowUpSystemUI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.RegisterSingleton<IMqttDataService>(new MqttDataService(DependencyService.Get<IEventAggregator>()));
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
