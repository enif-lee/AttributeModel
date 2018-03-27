using System.Reflection;
using JetBrains.Annotations;

namespace AttributeModel.Core.SimpleInjector.Configuration
{
    public class DefaultSetting : RegistrationSetting
    {
        [CanBeNull] public RegistrationSetting ServiceSetting { get; set; }
        [CanBeNull] public RegistrationSetting RepositorySetting { get; set; }

        public DefaultSetting()
        {
        }
        
        public DefaultSetting([NotNull] Assembly assembly) : base(assembly)
        {
        }
    }
}
