using System;
using Prism.Events;

namespace GrowUpSystemUI.Models
{
    public class MqttMessageTransport : PubSubEvent<MqttMessageTransport>
    {
        public string Topic { get; set; }
        public string Message { get; set; }
    }
}
