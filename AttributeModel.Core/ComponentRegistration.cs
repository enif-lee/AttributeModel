using System;

namespace AttributeModel.Core
{
    public class ComponentRegistration : IEquatable<ComponentRegistration>
    {
        public Type InterfaceType { get; set; }
        public Type ClassType { get; set; }
        public LifestyleType LifestyleType { get; set; }

        public bool Equals(ComponentRegistration other)
        {
            return InterfaceType == other.InterfaceType;
        }
    }
}
