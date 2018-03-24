using System;
using AttributeModel.Test.Context;
using AttributeModel.Test.Context.Repository;
using AttributeModel.Test.Context.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttributeModel.Test.Core.SimpleInjector
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        [DataRow(typeof(ISampleRepository), typeof(DeepSampleRepository))]
        [DataRow(typeof(ISampleService), typeof(DeepSampleService))]
        public void should_use_registered_assembly_when_configuration_instance_is_exists(Type Interface, Type implemented)
        {
            // Vim 쓰기 어렵다 ㅎㅎ.
        }
    }
}
