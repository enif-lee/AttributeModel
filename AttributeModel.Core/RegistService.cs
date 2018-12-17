using System;
using System.Collections;
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


        private IEnumerable<Type> _ignoreDefaultInterfaces = new List<Type>
        {
            typeof(IList),
            typeof(IEnumerable),
            typeof(IEnumerator),
            typeof(IDisposable),
            typeof(ICloneable),
            typeof(IQueryable),
            typeof(ICollection)

        };

        public void Register(IEnumerable<Type> types)
        {
            (Type Interface, Type Implemented, LifestyleType LifeStyle) ValueTuple(Type interfaceType, Type type)
            {
                return (
                    Interface: interfaceType,
                    Implemented: type,
                    LifeStyle: type.GetCustomAttribute<ComponentAttribute>(true).LifestyleType
                );
            }

            types
                .Where(type => type.GetCustomAttribute<ComponentAttribute>(true) != null)
                .SelectMany(type =>
                {
                    var definedInterfaces = type.GetInterfaces().Except(_ignoreDefaultInterfaces).ToArray();

                    return definedInterfaces.Any()
                        ? definedInterfaces.Select(interfaceType => ValueTuple(interfaceType, type))
                        : new[] {ValueTuple(type, type)};
                })
                .ToList()
                .ForEach(meta => ResolveLoader.Resolve(meta.Interface, meta.Implemented, meta.LifeStyle));
        }
    }
}
