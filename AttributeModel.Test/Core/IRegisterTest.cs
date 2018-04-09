namespace AttributeModel.Test.Core
{
    public interface IRegisterTest
    {
        void should_regist_components();
        void should_return_only_same_instance_when_lifestyle_is_singleton();
        void should_return_same_unregistered_instance_when_lifestyle_is_singleton();
        void should_return_other_unregisted_instance_when_lifestyle_is_transient();
        void should_throw_error_when_request_unregisterd_interface_type();
    }
}
