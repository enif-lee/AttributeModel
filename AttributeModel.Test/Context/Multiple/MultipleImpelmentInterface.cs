using System;
using AttributeModel.Core.Attributes;

namespace AttributeModel.Test.Context.Multiple
{
    [Service]
    public class MultipleImpelmentInterface : IMultipleFirst, IMultipleSecond, IDisposable
    {
        public void Dispose()
        {
        }
    }
}
