using System;
using System.Threading.Tasks;
using GrowUpSystemUI.Services;
using Xamarin.Forms;

namespace GrowUpSystemUI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.RegisterSingleton<IMqttDataService>(new MqttDataService());
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            var _mqttDataService = DependencyService.Get<IMqttDataService>();
            Task.Run(async () =>
            {
                await _mqttDataService.Initialize();
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }



    }
}
