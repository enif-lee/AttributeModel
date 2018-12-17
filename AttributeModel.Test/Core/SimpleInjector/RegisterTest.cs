using System;
using AttributeModel.Core.SimpleInjector;
using AttributeModel.Test.Context;
using AttributeModel.Test.Context.Multiple;
using AttributeModel.Test.Core.SimpleInjector.Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace AttributeModel.Test.Core.SimpleInjector
{
    [TestClass]
    public class RegisterTest : IRegisterTest
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


        [TestMethod]
        public void should_return_same_unregistered_instance_when_lifestyle_is_singleton()
        {
            var a = _container.GetInstance<UnregisterTypeSingleton>();
            var b = _container.GetInstance<UnregisterTypeSingleton>();
            
            a.Should().BeEquivalentTo(b);
        }

        [TestMethod]
        public void should_return_other_unregisted_instance_when_lifestyle_is_transient()
        {
            var a = _container.GetInstance<UnregisterTypeTransient>();
            var b = _container.GetInstance<UnregisterTypeTransient>();
            
            a.Should().NotBe(b);
        }

        [TestMethod]
        public void should_return_singleton_instance_as_default_when_unregisted_type_hasnt_component_attribute()
        {
            var a = _container.GetInstance<UnregisterTypeWithoutAttribute>();
            var b = _container.GetInstance<UnregisterTypeWithoutAttribute>();
            
            a.Should().BeEquivalentTo(b);
        }

        [TestMethod]
        public void should_throw_error_when_request_unregisterd_interface_type()
        {
            var action = new Action(() => { _container.GetInstance<UnregisteredInterface>(); });

            action.Should().ThrowExactly<ActivationException>("No registration for type UnregisteredInterface could be found.");
        }

        [TestMethod]
        public void should_register_multiple_type_when_the_class_implement_multiple_interfaces()
        {
            var a = _container.GetInstance<IMultipleFirst>();
            var b = _container.GetInstance<IMultipleSecond>();

            a.Should().BeEquivalentTo(b);
        }

        [TestMethod]
        public void should_ignore_registration_default_interface_types_about_provided_from_standard_library()
        {
            var action = new Action(() => { _container.GetInstance<IDisposable>(); });

            action.Should().ThrowExactly<ActivationException>("No registration for type UnregisteredInterface could be found.");
        }
    }
}
