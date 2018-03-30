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

        public void RegisterComponents<T>(IEnumerable<Type> types, LifestyleType lifestyleType) where T : ComponentAttribute
        {
            var registrations = types
                .Where(type => type.GetCustomAttribute<T>(true) != null)
                .Select(type => new ComponentRegistration
                {
                    InterfaceType = type.GetInterfaces().SingleOrDefault() ?? type,
                    ClassType = type,
                    LifestyleType = type.GetCustomAttribute<T>(true).LifestyleType ?? lifestyleType
                });

            RegisterComponents(registrations);
        }

        public void RegisterComponents(IEnumerable<ComponentRegistration> componentRegistrations)
        {
            componentRegistrations.ToList().ForEach(ResolveLoader.Resolve);
        }
    }
}
