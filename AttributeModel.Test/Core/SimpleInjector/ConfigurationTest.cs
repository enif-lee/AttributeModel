using System.Linq;
using System.Reflection;
using AttributeModel.Core.SimpleInjector;
using AttributeModel.Core.SimpleInjector.Configuration;
using AttributeModel.Test.Context.Repository;
using AttributeModel.Test.Context.Service;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace AttributeModel.Test.Core.SimpleInjector
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void should_use_registered_assembly_when_repository_settings_is_exist()
        {
            var container = new Container();
            
            container.UseAttributeModel(new DefaultSetting
            {
                Assembly = null,
                RepositorySetting =  new RegistrationSetting
                {
                    Assembly = typeof(DeepSampleRepository).Assembly
                }
            });

            container.GetInstance<IDeepSampleRepository>().Should().BeOfType<DeepSampleRepository>();
        }

        [TestMethod]
        public void should_use_registered_assembly_when_service_settings_is_exist()
        {
            var container = new Container();
            
            container.UseAttributeModel(new DefaultSetting
            {
                ServiceSetting = new RegistrationSetting
                {
                    Assembly = typeof(DeepSampleService).Assembly
                }
            });

            container.GetInstance<IDeepSampleService>().Should().BeOfType<DeepSampleService>();
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
