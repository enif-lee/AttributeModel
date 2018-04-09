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
        ///     Register calling assembly as default.
        ///     Default life style is scoped.
        /// </summary>
        /// <param name="container">ioc container</param>
        public static void UseAttributeModel(this Container container)
        {
            container.UseAttributeModel(Assembly.GetCallingAssembly().ExportedTypes, LifestyleType.Scoped);
        }

        /// <summary>
        ///     Register components using assembly from parameter
        /// </summary>
        /// <param name="container">ioc container</param>
        /// <param name="types">assemblies</param>
        /// <param name="defaultLifestyle">ComponentAttrbute default lifestyle</param>
        public static void UseAttributeModel(this Container container, IEnumerable<Type> types,
            LifestyleType defaultLifestyle)
        {
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

            GetRegisterService(container).RegisterComponents(types);
        }

        private static RegistService GetRegisterService(Container container)
        {
            return new RegistService(new ResolveLoader(container));
        }

        public static void UseAttributeModel(this Container container, DefaultSetting setting)
        {
            if (setting.Assembly == null)
                throw new ArgumentNullException("There are no base base assembly to registration.");

            var registrationSettings = setting.ComponentSettings.Reverse().ToList();

            var types = setting.Assembly.ExportedTypes
                .Where(type => type.GetCustomAttribute<ComponentAttribute>(true) != null)
                .Select(type =>
                {
                    var componentMeta = type.GetCustomAttribute<ComponentAttribute>(true);
                    return new ComponentRegistration
                    {
                        InterfaceType = type.GetInterfaces().FirstOrDefault() ?? type,
                        ClassType = type,
                        LifestyleType = componentMeta.LifestyleType ??
                                        registrationSettings.FirstOrDefault(s =>
                                            s.ComponentType == componentMeta.GetType() &&
                                            type.Namespace.StartsWith(s.Namespace ?? type.Namespace)
                                        )?.LifestyleType ??
                                        setting.LifestyleType
                    };
                });

            GetRegisterService(container).RegisterComponents(types);
        }
    }
}
