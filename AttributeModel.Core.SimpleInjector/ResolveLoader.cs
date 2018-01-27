using System;
using SimpleInjector;

namespace AttributeModel.Core.SimpleInjector
{
    internal class ResolveLoader : IResolveLoader
    {
        public Container Container { get; }

        public ResolveLoader(Container container)
        {
            Container = container;
        }

        public void Resolve(Type interfaceType, Type implemented, LifestyleType lifestyleType)
        {
            Container.Register(interfaceType, implemented, LifeStyleFactory.Create(lifestyleType));
        }
    }
}