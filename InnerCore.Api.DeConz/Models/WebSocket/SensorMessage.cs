using InnerCore.Api.DeConz.Models.Sensors;
using System.Runtime.Serialization;

namespace InnerCore.Api.DeConz.Models.WebSocket
{
    [DataContract]
    public class SensorMessage : Message
    {
        [DataMember]
        public SensorState State { get; set; }

        [DataMember]
        public SensorConfig Config { get; set; }
    }
}
