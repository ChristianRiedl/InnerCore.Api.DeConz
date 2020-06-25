using System.Runtime.Serialization;

namespace InnerCore.Api.DeConz.Models.WebSocket
{
    [DataContract]
    public class LightMessage : Message
    {
        [DataMember]
        public LightState State { get; set; }
    }
}
