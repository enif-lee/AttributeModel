using AttributeModel.Core.SimpleInjector;
using AttributeModel.Test.Context;
using AttributeModel.Test.Core.SimpleInjector.Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace AttributeModel.Test.Core.SimpleInjector
{
    [TestClass]
    public class RegistTest
    {
        private Container _container;

        [TestInitialize]
        public void Setup()
        {
            _container = new Container
            {
                Options =
                {
                    DefaultScopedLifestyle = new TestScopedLifestyle(),
                }
            };
            _container.Regist();
        }
        
        [TestMethod]
        public void should_regist_components()
        {
            _container.GetInstance<SampleComponent>().Should().NotBeNull();
            _container.GetInstance<ISampleService>().Should().NotBeNull();
            _container.GetInstance<ISampleRepository>().Should().NotBeNull();
        }

        [TestMethod]
        public void should_return_only_same_instance_when_lifestyle_is_singleton()
        {
            var a = _container.GetInstance<ISampleComponent>();
            var b = _container.GetInstance<ISampleComponent>();
            
            a.Should().Be(b);
        }
    }
}