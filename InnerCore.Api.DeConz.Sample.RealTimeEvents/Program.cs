using System;
using System.Threading.Tasks;

namespace InnerCore.Api.DeConz.Sample.RealTimeEvents
{
    class Program
    {
        public static async Task Main()
        {
            // Initialize the client

            Console.WriteLine("ip (without port):");
            var ip = Console.ReadLine();

            Console.WriteLine("appkey:");
            var appKey = Console.ReadLine();

            var client = new DeConzClient(ip, appKey);

            // test the connection

            Console.WriteLine("connecting...");
            var online = await client.CheckConnection();

            if (!online)
            {
                Console.WriteLine("...unable to connect!");
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("...connected successfully!");

            // setup the events

            client.SensorChanged += Client_SensorChanged;
            client.LightChanged += Client_LightChanged;
            client.GroupChanged += Client_GroupChanged;
            client.SceneCalled += Client_SceneCalled;
            client.ErrorEvent += Client_ErrorEvent;

            // start listening to events (infinite as long as the server does not close the connection)

            Console.WriteLine("Listening to events...");
            await client.ListenToEvents();
        }

        private static void Client_SensorChanged(object sender, Models.WebSocket.SensorChangedEvent e)
        {
            if (e.Config != null)
            {
                Console.WriteLine($"Sensor {e.Id} has changed it's config");
            }

            if (e.State != null)
            {
                Console.WriteLine($"Sensor {e.Id} has changed it's state");
            }
        }
        private static void Client_LightChanged(object sender, Models.WebSocket.LightChangedEvent e)
        {
            if (e.State != null)
            {
                //Console.WriteLine($"Light {e.Id} has changed it's state");
                Console.WriteLine($"Light {e.Id} B{e.State.Brightness} T{e.State.ColorTemperature} S{e.State.Saturation} H{e.State.Hue} {e.State.Mode} {e.State.ColorMode} {e.State.ColorCoordinates[0]}/{e.State.ColorCoordinates[1]} ");
            }
        }
        private static void Client_GroupChanged(object sender, Models.WebSocket.GroupChangedEvent e)
        {
            Console.WriteLine($"Group {e.Id} has changed it's state");
        }
        private static void Client_SceneCalled(object sender, Models.WebSocket.SceneCalledEvent e)
        {
            Console.WriteLine($"Scene {e.GroupId}/{e.SceneId} has been called");
        }

        private static void Client_ErrorEvent(object sender, Models.WebSocket.ErrorEvent e)
        {
            var originalColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"error while handling a message: {e.Ex.Message}");
            Console.BackgroundColor = originalColor;
        }
    }
}
