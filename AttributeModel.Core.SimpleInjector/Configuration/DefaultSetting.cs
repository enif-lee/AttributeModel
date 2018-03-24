namespace AttributeModel.Core.SimpleInjector.Configuration
{
    public class DefaultSetting : RegistrationSetting
    {
        public RegistrationSetting ServiceSetting { get; set; }
        public RegistrationSetting RepositorySetting { get; set; }
    }
}
