using System;
using System.Reflection;
using AttributeModel.Core.Attributes;
using SimpleInjector;

namespace AttributeModel.Core.SimpleInjector
{
    public static class ContainerExtensions
    {
        public static void Regist(this Container container)
        {
            var service = new RegistService(new ResolveLoader(container));

            container.ResolveUnregisteredType += (sender, e) =>
            {
                var unregistered = e.UnregisteredServiceType;
                var component = unregistered.GetCustomAttribute<ComponentAttribute>(true);

                if (component == null) return;
                
                var registration = LifeStyleFactory
                    .Create(component.LifestyleType)
                    .CreateRegistration(unregistered, container);
                    
                e.Register(registration);
            };
            
            service.Regist(Assembly.GetCallingAssembly().ExportedTypes);
        }
    }
}