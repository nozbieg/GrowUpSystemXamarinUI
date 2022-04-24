using System;
using System.Threading.Tasks;

namespace GrowUpSystemUI.Services
{
    public interface IMqttDataService
    {
        Task Initialize();
        Task PublishMqttMessageAsync(string publishmessage, string topic);
    }
}
