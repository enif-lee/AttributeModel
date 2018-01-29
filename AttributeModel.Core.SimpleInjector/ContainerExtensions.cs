using System;
using System.Collections.Generic;
using System.Reflection;
using AttributeModel.Core.Attributes;
using SimpleInjector;

namespace AttributeModel.Core.SimpleInjector
{
    public static class ContainerExtensions
    {
        /// <summary>
        /// Register calling assembly as default
        /// </summary>
        /// <param name="container">ioc container</param>
        public static void Regist(this Container container)
        {
            container.Regist(Assembly.GetCallingAssembly().ExportedTypes);
        }

        /// <summary>
        /// Register components using assembly from parameter
        /// </summary>
        /// <param name="container">ioc container</param>
        /// <param name="types">assemblies</param>
        public static void Regist(this Container container, IEnumerable<Type> types)
        {
            var service = new RegistService(new ResolveLoader(container));

            container.ResolveUnregisteredType += (sender, e) =>
            {
                var unregistered = e.UnregisteredServiceType;
                var component = unregistered.GetCustomAttribute<ComponentAttribute>(true);

                var lifestyle = component == null
                    ? Lifestyle.Singleton
                    : LifeStyleFactory.Create(component.LifestyleType);
                
                var registration = lifestyle.CreateRegistration(unregistered, container);

                e.Register(registration);
            };

            service.Regist(types);
        }
    }
}