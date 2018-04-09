using System.Collections.Generic;
using System.Reflection;
using AttributeModel.Core.Attributes;
using JetBrains.Annotations;

namespace AttributeModel.Core.SimpleInjector.Configuration
{
    public class DefaultSetting
    {
        private static readonly RegistrationSetting<ServiceAttribute> ServiceSetting =
            new RegistrationSetting<ServiceAttribute>(LifestyleType.Scoped);

        private static readonly RegistrationSetting<RepositoryAttribute> RepositorySetting =
            new RegistrationSetting<RepositoryAttribute>(LifestyleType.Scoped);

        public DefaultSetting([NotNull] Assembly assembly,
            [NotNull] IEnumerable<IRegistrationSetting> componentSettings)
        {
            Assembly = assembly;
            ComponentSettings = componentSettings;
        }

        public DefaultSetting([NotNull] Assembly assembly)
        {
            Assembly = assembly;
            ComponentSettings = new IRegistrationSetting[] {ServiceSetting, RepositorySetting};
        }

        [NotNull] public Assembly Assembly { get; set; }
        [NotNull] public IEnumerable<IRegistrationSetting> ComponentSettings { get; set; }
        public LifestyleType LifestyleType { get; set; } = LifestyleType.Singleton;
    }
}
