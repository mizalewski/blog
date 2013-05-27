namespace MefInterception
{
    public class SayArgs
    {
        public SayArgs(string text)
        {
            this.Text = text;
        }

        public string Text { get; private set; }
    }
}