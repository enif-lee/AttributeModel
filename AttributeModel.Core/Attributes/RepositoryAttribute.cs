namespace AttributeModel.Core.Attributes
{
    public class RepositoryAttribute : ComponentAttribute
    {
        public RepositoryAttribute(LifestyleType lifestyleType = LifestyleType.Scoped, string name = null) : base(lifestyleType, name)
        {
        }
    }
}