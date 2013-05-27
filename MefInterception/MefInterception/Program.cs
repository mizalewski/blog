using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using MefContrib.Hosting.Interception;
using MefContrib.Hosting.Interception.Configuration;
using MefInterception.Interception;

namespace MefInterception
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            InterceptionConfiguration cfg = new InterceptionConfiguration();
            cfg.AddInterceptor(new MefContrib.Hosting.Interception.Castle.DynamicProxyInterceptor(new CastleLoggingInterceptor()));
            InterceptingCatalog interceptingCatalog = new InterceptingCatalog(assemblyCatalog, cfg);

            CompositionContainer container = new CompositionContainer(interceptingCatalog);
            ISampleInterface intercepted = container.GetExportedValue<ISampleInterface>();
            intercepted.Say("Hello World!");
            intercepted.Say(new SayArgs("Hello World with args!"));
        }
    }
}