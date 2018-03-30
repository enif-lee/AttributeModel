using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttributeModel.Test
{
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void DistinctTest()
        {
            var test = new A[]{new A{ Value = "First Item" }, new A{ Value = "Second Item"}, new A{ Value = "Third Item"}};

            test.Distinct().First().Value.Should().Be("Third Item");

        }

    }


    public class A : IEquatable<A>
    {
        public string Value { get; set; }


        public bool Equals(A other)
        {
            return true;
        }
    }
}
