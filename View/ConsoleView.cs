using System;
using ServerApp.Model;

namespace ServerApp.View
{
    public class ConsoleView
    {
        public string GetInput(string sender)
        {
            Console.Write($"{sender}: ");
            return Console.ReadLine();
        }

        public void ShowMessage(Message msg)
        {
            Console.WriteLine($"{msg.Sender}: {msg.Text}");
        }

        public void ShowInfo(string info)
        {
            Console.WriteLine($"[INFO] {info}");
        }

        public void ShowError(string error)
        {
            Console.WriteLine($"[ERROR] {error}");
        }
    }
}
