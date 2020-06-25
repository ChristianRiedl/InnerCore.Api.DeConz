using System;

namespace InnerCore.Api.DeConz.Models.WebSocket
{
    public class SceneCalledEvent : EventArgs
    {
	public int GroupId { get; set; }
	public int SceneId { get; set; }
    }
}
