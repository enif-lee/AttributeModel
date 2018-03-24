using System.Reflection;

namespace AttributeModel.Core.SimpleInjector.Configuration
{
    public class RegistrationSetting
    {
        public Assembly Assembly { get; set; }
        public LifestyleType LifestyleType { get; set; }
    }
}
