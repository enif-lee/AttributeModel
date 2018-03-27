using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AttributeModel.Core.Attributes;

namespace AttributeModel.Core
{
    public class RegistService
    {
        public IResolveLoader ResolveLoader { get; set; }

        public RegistService(IResolveLoader resolveLoader)
        {
            ResolveLoader = resolveLoader;
        }

        public void RegisterComponents(IEnumerable<Type> types)
        {
            RegisterComponents<ComponentAttribute>(types, LifestyleType.Singleton);
        }

        private void RegisterComponents<T>(IEnumerable<Type> types, LifestyleType lifestyleType) where T : ComponentAttribute
        {
            types
                .Where(type => type.GetCustomAttribute<T>(true) != null)
                .Select(type => (
                    Interface: type.GetInterfaces().SingleOrDefault() ?? type,
                    Implemented: type,
                    LifeStyle: type.GetCustomAttribute<T>(true).LifestyleType ?? lifestyleType
                ))
                .ToList()
                .ForEach(meta => ResolveLoader.Resolve(meta.Interface, meta.Implemented, meta.LifeStyle));
        }
    }
}
