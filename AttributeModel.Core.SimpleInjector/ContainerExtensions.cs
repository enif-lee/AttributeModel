using System;
using SimpleInjector;

namespace AttributeModel.Core.SimpleInjector
{
    public static class ContainerExtensions
    {
        public static void Regist(this Container container)
        {
            var service = new RegistService(new ResolveLoader(container));
            
            service.Regist();
        }
    }
}