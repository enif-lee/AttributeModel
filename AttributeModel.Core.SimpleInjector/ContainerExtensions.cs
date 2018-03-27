using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AttributeModel.Core.Attributes;
using AttributeModel.Core.SimpleInjector.Configuration;
using SimpleInjector;

namespace AttributeModel.Core.SimpleInjector
{
    public static class ContainerExtensions
    {
        /// <summary>
        /// Register calling assembly as default.
        /// Default life style is scoped.
        /// </summary>
        /// <param name="container">ioc container</param>
        public static void UseAttributeModel(this Container container)
        {
            container.UseAttributeModel(Assembly.GetCallingAssembly().ExportedTypes, LifestyleType.Scoped);
        }

        /// <summary>
        /// Register components using assembly from parameter
        /// </summary>
        /// <param name="container">ioc container</param>
        /// <param name="types">assemblies</param>
        /// <param name="defaultLifestyle">ComponentAttrbute default lifestyle</param>
        public static void UseAttributeModel(this Container container, IEnumerable<Type> types, LifestyleType defaultLifestyle)
        {
            var service = new RegistService(new ResolveLoader(container));

            container.ResolveUnregisteredType += (sender, e) =>
            {
                var unregistered = e.UnregisteredServiceType;

                if (!unregistered.IsClass || !unregistered.GetConstructors().Any(info => info.IsPublic))
                    return;
                
                var component = unregistered.GetCustomAttribute<ComponentAttribute>(true);
                    
                var lifestyle = component == null
                    ? Lifestyle.Singleton
                    : LifeStyleFactory.Create(component.LifestyleType ?? defaultLifestyle);
                    
                var registration = lifestyle.CreateRegistration(unregistered, container);
    
                e.Register(registration);
            };

            service.RegisterComponents(types);
        }

        public static void UseAttributeModel(this Container container, DefaultSetting setting)
        {
            if(setting.Assembly == null && setting.ServiceSetting?.Assembly == null && setting.RepositorySetting?.Assembly == null)
                throw new ArgumentNullException("There are no base base assemblies to registration.");

            var types = new[]
                {
                    setting.Assembly?.ExportedTypes, 
                    setting.ServiceSetting?.Assembly?.ExportedTypes,
                    setting.RepositorySetting?.Assembly?.ExportedTypes
                }
                .Where(e => e != null)
                .SelectMany(e => e)
                .Distinct();
            
            UseAttributeModel(container, types, setting.LifestyleType);
            
            
        }
    }
}
