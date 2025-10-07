namespace ServerApp.Model
{
    public class Message
    {
        public string Text { get; set; }
        public string Sender { get; set; }

        public Message(string text, string sender)
        {
            Text = text;
            Sender = sender;
        }
    }
}

