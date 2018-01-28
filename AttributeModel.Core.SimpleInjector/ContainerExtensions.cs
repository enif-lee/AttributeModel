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

            // Todo 
            container.ResolveUnregisteredType += (sender, e) =>
            {
                var component = e.UnregisteredServiceType.GetCustomAttribute<ComponentAttribute>(true);

                if (component != null)
                {
                    
                }
            };
            
            service.Regist(Assembly.GetCallingAssembly().ExportedTypes);
        }
    }
}