using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using MefContrib.Hosting.Generics;

namespace MefGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            GenericCatalog genericCatalog = new GenericCatalog(new GenericContractRegistry());
            AggregateCatalog aggregateCatalog = new AggregateCatalog(assemblyCatalog, genericCatalog);

            CompositionContainer container = new CompositionContainer(aggregateCatalog);
            var sampleClass = container.GetExportedValue<SampleClass>();
            sampleClass.SayHello();

            Console.ReadKey();
        }
    }
}
