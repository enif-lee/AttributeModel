namespace AttributeModel.Core.Attributes
{
    public class ServiceAttribute : ComponentAttribute
    {
        public ServiceAttribute()
        {
        }

        public ServiceAttribute(LifestyleType lifestyleType) : base(lifestyleType)
        {
        }
    }
}
