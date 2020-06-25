using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace InnerCore.Api.DeConz.Models.WebSocket
{
    [DataContract]
    public class GroupMessage : Message
    {
	[JsonProperty("all_on")]
	public bool AllOn { get; set; }
	[JsonProperty("any_on")]
	public bool AnyOn { get; set; }
    }
}
