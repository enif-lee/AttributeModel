using System;

namespace AttributeModel.Test
{
    public class A : IEquatable<A>
    {
        public string Value { get; set; }


        public bool Equals(A other)
        {
            return true;
        }
    }
}
