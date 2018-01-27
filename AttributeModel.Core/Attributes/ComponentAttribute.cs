using System;

namespace AttributeModel.Core.Attributes
{
    public class ComponentAttribute : Attribute
    {
        public LifestyleType LifestyleType { get; set; }
        public string Name { get; set; }

        public ComponentAttribute(LifestyleType lifestyleType, string name = null)
        {
            LifestyleType = lifestyleType;
            Name = name;
        }
    }
}