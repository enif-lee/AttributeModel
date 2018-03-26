using System.Reflection;
using JetBrains.Annotations;

namespace AttributeModel.Core.SimpleInjector.Configuration
{
    public class RegistrationSetting
    {
        public RegistrationSetting([NotNull] Assembly assembly)
        {
            Assembly = assembly;
        }

        public RegistrationSetting([NotNull] Assembly assembly, LifestyleType lifestyleType)
        {
            Assembly = assembly;
            LifestyleType = lifestyleType;
        }

        [NotNull] public Assembly Assembly { get; set; }

        /// <summary>
        /// Default as singleton
        /// </summary>
        public LifestyleType LifestyleType { get; set; } = LifestyleType.Singleton;
    }
}
