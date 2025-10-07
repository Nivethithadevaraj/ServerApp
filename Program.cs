using ServerApp.Model;
using ServerApp.View;
using ServerApp.Controller;

namespace ServerApp
{
    class Program
    {
        static void Main()
        {
            ConsoleView view = new ConsoleView();
            ChatServer server = new ChatServer();
            ServerController controller = new ServerController(view, server);

            controller.Run(8888); // you can change port here
        }
    }
}
