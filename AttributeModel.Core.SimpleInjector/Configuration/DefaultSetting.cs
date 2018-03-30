using System.Collections.Generic;
using System.Reflection;
using AttributeModel.Core.Attributes;
using JetBrains.Annotations;

namespace AttributeModel.Core.SimpleInjector.Configuration
{
    public class DefaultSetting
    {
        [NotNull] public Assembly Assembly { get; set; }
        [NotNull] public IEnumerable<IRegistrationSetting> ComponentSettings { get; set; }
        public LifestyleType LifestyleType { get; set; } = LifestyleType.Singleton;

        private static readonly RegistrationSetting<ServiceAttribute> _serviceSetting =
            new RegistrationSetting<ServiceAttribute>(LifestyleType.Scoped);

        private static readonly RegistrationSetting<RepositoryAttribute> _repositorySetting =
            new RegistrationSetting<RepositoryAttribute>(LifestyleType.Scoped);

        public DefaultSetting([NotNull] Assembly assembly, [NotNull] IEnumerable<IRegistrationSetting> componentSettings)
        {
            Assembly = assembly;
            ComponentSettings = componentSettings;
        }

        public DefaultSetting([NotNull] Assembly assembly)
        {
            Assembly = assembly;
            ComponentSettings = new IRegistrationSetting[] {_serviceSetting, _repositorySetting};
        }
    }
}
