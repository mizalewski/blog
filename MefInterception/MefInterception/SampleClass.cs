using System;
using System.ComponentModel.Composition;

namespace MefInterception
{
    [Export(typeof(ISampleInterface))]
    public class SampleClass : ISampleInterface
    {
        public void Say(string text)
        {
            Console.WriteLine("InterceptedClass say: " + text);
        }

        public void Say(SayArgs args)
        {
            Console.WriteLine(args.Text);
        }
    }
}
