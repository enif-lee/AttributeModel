namespace AttributeModel.Core.Attributes
{
    public class ServiceAttribute : ComponentAttribute
    {
        public ServiceAttribute(LifestyleType lifestyleType = LifestyleType.Scoped, string name = null) : base(lifestyleType, name)
        {
        }
    }
}