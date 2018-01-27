using System.Collections.Generic;
using SimpleInjector;

namespace AttributeModel.Core.SimpleInjector
{
    internal class LifeStyleFactory
    {
        private static readonly IDictionary<LifestyleType, Lifestyle> Types = new Dictionary<LifestyleType, Lifestyle>
        {
            { LifestyleType.Scoped, Lifestyle.Scoped },
            { LifestyleType.Transient, Lifestyle.Transient },
            { LifestyleType.Singleton, Lifestyle.Singleton }
        };

        public static Lifestyle Create(LifestyleType type) => Types[type];
    }
}