namespace MefInterception
{
    public interface ISampleInterface
    {
        void Say(string text);

        void Say(SayArgs args);
    }
}