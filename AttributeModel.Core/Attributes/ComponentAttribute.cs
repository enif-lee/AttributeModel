using System;
using JetBrains.Annotations;

namespace AttributeModel.Core.Attributes
{
    public class ComponentAttribute : Attribute, IComponentAttribute
    {
        [CanBeNull] public LifestyleType? LifestyleType { get; set; }

        public ComponentAttribute()
        {
        }
        
        public ComponentAttribute(LifestyleType lifestyleType)
        {
            LifestyleType = lifestyleType;
        }
    }
}
