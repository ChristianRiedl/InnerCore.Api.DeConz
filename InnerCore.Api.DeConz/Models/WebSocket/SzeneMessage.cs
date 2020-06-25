using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace InnerCore.Api.DeConz.Models.WebSocket
{
    [DataContract]
    public class SzeneMessage : Message
    {
	[JsonProperty("gid")]
	public int GroupId { get; set; }
	[JsonProperty("scid")]
	public int SceneId { get; set; }
    }
}
