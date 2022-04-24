using System;
using System.Threading.Tasks;
using GrowUpSystemUI.Services;
using Xamarin.Forms;

namespace GrowUpSystemUI.ViewModels
{
    public class TemperatureViewModel
    {

        public string Temperature { get; set; }
        IMqttDataService _mqttDataService;
        public TemperatureViewModel()
        {
            Temperature = "26";
            _mqttDataService = DependencyService.Get<IMqttDataService>();
            Task.Run(async () =>
            {
                await _mqttDataService.Initialize();
            });
        }
    }
}
