using System;

namespace AttributeModel.Core
{
    public interface IResolveLoader
    {
        void Resolve(Type interfaceType, Type implemented, LifestyleType lifestyleType);
        void Resolve(ComponentRegistration registration);
    }
}
