using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using MefContrib.Hosting.Interception;
using MefContrib.Hosting.Interception.Configuration;
using MefContrib.Hosting.Interception.LinFu;
using MefContrib.Hosting.Generics;

namespace UnityInterceptionLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            InterceptionConfiguration cfg = new InterceptionConfiguration()
                .AddInterceptor(new DynamicProxyInterceptor(new LoggingInterceptor()));

            //GenericTypeCatalog typeCatalog = new GenericTypeCatalog(typeof(GenericClass<int>), typeof(IGenericInterface<>));
            //AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            //AggregateCatalog aggregateCatalog = new AggregateCatalog(assemblyCatalog, typeCatalog);
            //GenericCatalog genericCatalog = new GenericCatalog(aggregateCatalog);
            //InterceptingCatalog interceptingCatalog = new InterceptingCatalog(genericCatalog, cfg);
            //CompositionContainer container = new CompositionContainer(interceptingCatalog);

//            GenericContractTypeMapping mapping = new GenericContractTypeMapping(typeof(IGenericInterface<>), typeof(GenericClass<>));

            TypeCatalog typeCatalog = new TypeCatalog(typeof(SampleClass), typeof(OrderProcessor), typeof(CtorOrderProcessor));
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            GenericCatalog genericCatalog = new GenericCatalog(new TestGenericContractRegistry());
            AggregateCatalog aggregateCatalog = new AggregateCatalog(typeCatalog, genericCatalog);
            //CompositionContainer container = new CompositionContainer(aggregateCatalog);

            CompositionContainer container = new CompositionContainer(aggregateCatalog);
            var orderProcessor = container.GetExportedValue<OrderProcessor>();
            var generic = container.GetExportedValue<IGenericInterface<string>>();

            CatalogExportProvider provider = new CatalogExportProvider(aggregateCatalog);
            provider.SourceProvider = provider;

            var instance = provider.GetExportedValue<ISampleInterface>();//container.GetExportedValue<ISampleInterface>();
            instance.Method1("test", 5);

            var genericInstance = provider.GetExportedValue<OrderProcessor>();//container.GetExportedValue<IGenericInterface<int>>();
            //var orderProcessor = provider.GetExportedValue<CtorOrderProcessor>();
        }

        [Export(typeof(TestGenericContractRegistry))]
        public class TestGenericContractRegistry : GenericContractRegistryBase
        {
            protected override void Initialize()
            {
                this.Register(typeof(IGenericInterface<>), typeof(GenericClass<>));
            }
        }

        [Export]
        public class OrderProcessor
        {
            [Import]
            public IGenericInterface<int> OrderRepository { get; set; }
        }

        [Export]
        public class CtorOrderProcessor
        {
            [ImportingConstructor]
            public CtorOrderProcessor(IGenericInterface<string> orderRepository)
            {
                OrderRepository = orderRepository;
            }

            public IGenericInterface<string> OrderRepository { get; set; }
        }
    }
}
