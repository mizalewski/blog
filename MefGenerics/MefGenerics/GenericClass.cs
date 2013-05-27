using System;
using System.ComponentModel.Composition;

namespace MefGenerics
{
    [Export(typeof(IGenericInterface<>))]
    public class GenericClass<T> : IGenericInterface<T>
    {
        public void Hello()
        {
            Console.WriteLine("Hello World from generic with {0} type.", typeof(T));
        }
    }
}
