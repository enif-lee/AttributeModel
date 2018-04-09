using System;
using JetBrains.Annotations;

namespace AttributeModel.Core.Attributes
{
    public class ComponentAttribute : Attribute, IComponentAttribute
    {
        public ComponentAttribute()
        {
        }

        public ComponentAttribute(LifestyleType lifestyleType)
        {
            LifestyleType = lifestyleType;
        }

        [CanBeNull] public LifestyleType? LifestyleType { get; set; }
    }
}
