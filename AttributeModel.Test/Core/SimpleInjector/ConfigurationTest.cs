using System.Reflection;
using AttributeModel.Core.SimpleInjector;
using AttributeModel.Core.SimpleInjector.Configuration;
using AttributeModel.Test.Context;
using AttributeModel.Test.Context.Repository;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace AttributeModel.Test.Core.SimpleInjector
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void should_use_registered_assembly_when_configuration_instance_is_exist()
        {
            var container = new Container();
            
            container.UseAttributeModel(new DefaultSetting
            {
                Assembly = null,
                RepositorySetting =  new RegistrationSetting
                {
//                    Assembly = null
                    Assembly = typeof(DeepSampleRepository).Assembly
                }
            });

            container.GetInstance<ISampleRepository>().Should().BeOfType<DeepSampleRepository>();
            
            roslynTest(null);
        }

        
        
        public void roslynTest([NotNull] object test)
        {
            
        }
    }
}
