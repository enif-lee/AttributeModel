using System;
using SimpleInjector;

namespace AttributeModel.Core.SimpleInjector
{
    internal class ResolveLoader : IResolveLoader
    {
        public ResolveLoader(Container container)
        {
            Container = container;
        }

        public Container Container { get; }

        public void Resolve(Type interfaceType, Type implemented, LifestyleType lifestyleType)
        {
            Container.Register(interfaceType, implemented, LifeStyleFactory.Create(lifestyleType));
        }

        public void Resolve(ComponentRegistration registration)
        {
            Container.Register(
                registration.InterfaceType,
                registration.ClassType,
                LifeStyleFactory.Create(registration.LifestyleType)
            );
        }
    }
}
