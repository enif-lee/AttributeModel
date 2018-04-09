using System;
using System.Linq;
using AttributeModel.Core.Attributes;

namespace AttributeModel.Core.SimpleInjector.Configuration
{
    public class RegistrationSetting : IRegistrationSetting
    {
        public RegistrationSetting(Type type)
        {
            if (!type.GetInterfaces().Any(typeof(ComponentAttribute).Equals))
                throw new ArgumentException($"{nameof(type)} must extended {nameof(ComponentAttribute)}");
            ComponentType = type;
        }

        public RegistrationSetting(Type type, LifestyleType lifestyleType) : this(type)
        {
            LifestyleType = lifestyleType;
        }

        /// <inheritdoc />
        public LifestyleType LifestyleType { get; } = LifestyleType.Singleton;

        public string Namespace { get; }
        public Type ComponentType { get; set; }
    }

    public class RegistrationSetting<T> : RegistrationSetting where T : IComponentAttribute
    {
        public RegistrationSetting() : base(typeof(T), LifestyleType.Singleton)
        {
            ComponentType = typeof(T);
        }

        public RegistrationSetting(LifestyleType lifestyleType) : base(typeof(T), lifestyleType)
        {
        }
    }
}
