namespace AttributeModel.Core.Attributes
{
    public class ServiceAttribute : ComponentAttribute
    {
        public ServiceAttribute() : base()
        {
        }

        public ServiceAttribute(LifestyleType lifestyleType) : base(lifestyleType)
        {
        }
    }
}
