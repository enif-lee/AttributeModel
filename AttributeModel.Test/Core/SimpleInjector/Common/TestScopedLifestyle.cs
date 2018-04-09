using System;
using SimpleInjector;

namespace AttributeModel.Test.Core.SimpleInjector.Common
{
    public class TestScopedLifestyle : ScopedLifestyle
    {
        private readonly Scope _scope = new Scope();

        public TestScopedLifestyle() : base(nameof(TestScopedLifestyle))
        {
        }

        protected override Func<Scope> CreateCurrentScopeProvider(Container container)
        {
            return () => _scope;
        }
    }
}
