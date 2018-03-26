using System;

namespace AttributeModel.Core.Attributes
{
    public class ComponentAttribute : Attribute
    {
        public LifestyleType? LifestyleType { get; set; }

        public ComponentAttribute()
        {
        }
        
        public ComponentAttribute(LifestyleType lifestyleType)
        {
            LifestyleType = lifestyleType;
        }
    }
}
