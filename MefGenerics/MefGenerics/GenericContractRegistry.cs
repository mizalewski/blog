using MefContrib.Hosting.Generics;

namespace MefGenerics
{
    public class GenericContractRegistry : GenericContractRegistryBase
    {
        protected override void Initialize()
        {
            this.Register(typeof(IGenericInterface<>), typeof(GenericClass<>));
        }
    }
}
