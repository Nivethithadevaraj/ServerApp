using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp.Model
{
	public class ChatServer
	{
		private TcpListener listener;
		private TcpClient client;
		private NetworkStream stream;

		public void Start(int port)
		{
			listener = new TcpListener(IPAddress.Loopback, port);
			listener.Start();
			client = listener.AcceptTcpClient();
			stream = client.GetStream();
		}

		public string ReceiveMessage()
		{
			byte[] buffer = new byte[1024];
			int bytesRead = stream.Read(buffer, 0, buffer.Length);
			return Encoding.UTF8.GetString(buffer, 0, bytesRead);
		}

		public void SendMessage(string msg)
		{
			byte[] data = Encoding.UTF8.GetBytes(msg);
			stream.Write(data, 0, data.Length);
		}

		public void Stop()
		{
			stream?.Close();
			client?.Close();
			listener?.Stop();
		}
	}
}
