using System;
using System.Reflection;
using AttributeModel.Core.SimpleInjector;
using AttributeModel.Core.SimpleInjector.Configuration;
using AttributeModel.Test.Context;
using AttributeModel.Test.Core.SimpleInjector.Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace AttributeModel.Test.Core.SimpleInjector
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        [DataRow(typeof(ISampleService), typeof(SampleService), "TestScopedLifestyle")]
        [DataRow(typeof(ISampleRepository), typeof(SampleRepository), "TestScopedLifestyle")]
        [DataRow(typeof(ISampleComponent), typeof(SampleComponent), "Singleton")]
        public void should_registered_default_provided_component_type(Type interfaceType, Type classType,
            string type)
        {
            var container = new Container
            {
                Options = {DefaultScopedLifestyle = new TestScopedLifestyle()}
            };

            container.UseAttributeModel(new DefaultSetting(Assembly.GetExecutingAssembly()));

            container.GetInstance(interfaceType).Should().BeOfType(classType);
            container.GetRegistration(interfaceType).Lifestyle.Name.Should().BeEquivalentTo(type);
        }
    }
}
