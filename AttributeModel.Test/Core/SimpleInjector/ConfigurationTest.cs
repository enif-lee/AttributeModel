using System;
using System.Linq;
using System.Reflection;
using AttributeModel.Core;
using AttributeModel.Core.SimpleInjector;
using AttributeModel.Core.SimpleInjector.Configuration;
using AttributeModel.Test.Context;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace AttributeModel.Test.Core.SimpleInjector
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        [DataRow(typeof(ISampleService), typeof(SampleService), LifestyleType.Scoped)]
        [DataRow(typeof(ISampleRepository), typeof(SampleRepository), LifestyleType.Scoped)]
        [DataRow(typeof(ISampleComponent), typeof(SampleComponent), LifestyleType.Singleton)]
        public void should_registered_default_provided_component_type(Type interfaceType, Type classType,
            LifestyleType type)
        {
            var container = new Container();

            container.UseAttributeModel(new DefaultSetting(Assembly.GetExecutingAssembly()));

            container.GetInstance(interfaceType).Should().BeOfType(classType);
            container.GetRegistration(interfaceType).Lifestyle.Should().Be(LifeStyleFactory.Create(type));
        }


        [Ignore("This is just linq test for this branch.")]
        [TestMethod]
        public void LinqTest()
        {
            new[] {Assembly.GetExecutingAssembly().ExportedTypes, Assembly.GetExecutingAssembly().ExportedTypes}
                .SelectMany(e => e)
                .Distinct()
                .GroupBy(type => type)
                .Select(types => types.Count())
                .First()
                .Should().Be(1);
        }
    }
}
