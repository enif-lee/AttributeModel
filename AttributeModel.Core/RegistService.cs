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

        public void Regist(IEnumerable<Type> types)
        {
            types
                .Where(type => type.GetCustomAttribute<ComponentAttribute>(true) != null)
                .Where(type => type.GetInterfaces().Any())
                .Select(type => (
                    Interface: type.GetInterfaces().Single(), 
                    Implemented: type, 
                    LifeStyle: type.GetCustomAttribute<ComponentAttribute>(true).LifestyleType
                ))
                .ToList()
                .ForEach(meta => ResolveLoader.Resolve(meta.Interface, meta.Implemented, meta.LifeStyle));
        }

        public void Regist()
        {
            Regist(Assembly.GetCallingAssembly().GetExportedTypes());
        }
    }
}