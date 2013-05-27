using System.ComponentModel.Composition;

namespace MefGenerics
{
    [Export]
    public class SampleClass
    {
        private readonly IGenericInterface<int> intGeneric;
        private readonly IGenericInterface<string> stringGeneric;

        [ImportingConstructor]
        public SampleClass(IGenericInterface<string> stringGeneric, IGenericInterface<int> intGeneric)
        {
            this.stringGeneric = stringGeneric;
            this.intGeneric = intGeneric;
        }

        public void SayHello()
        {
            this.stringGeneric.Hello();
            this.intGeneric.Hello();
        }
    }
}
