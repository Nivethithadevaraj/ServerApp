using ServerApp.Model;
using ServerApp.View;

namespace ServerApp.Controller
{
    public class ServerController
    {
        private readonly ConsoleView view;
        private readonly ChatServer server;

        public ServerController(ConsoleView view, ChatServer server)
        {
            this.view = view;
            this.server = server;
        }

        public void Run(int port)
        {
            try
            {
                server.Start(port);
                view.ShowInfo($"Server started on 127.0.0.1:{port}");

                while (true)
                {
                    string clientMsg = server.ReceiveMessage();
                    var received = new Message(clientMsg, "Client");
                    view.ShowMessage(received);

                    if (clientMsg.ToLower() == "exit") break;

                    string reply = view.GetInput("Server");
                    server.SendMessage(reply);

                    if (reply.ToLower() == "exit") break;
                }
            }
            catch (Exception ex)
            {
                view.ShowError(ex.Message);
            }
            finally
            {
                server.Stop();
                view.ShowInfo("Server stopped.");
            }
        }
    }
}
