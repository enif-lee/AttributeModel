using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

[assembly: InternalsVisibleTo("AttributeModel.Test")]

namespace AttributeModel.Core.SimpleInjector.Configuration
{
    public interface IRegistrationSetting
    {
        [NotNull] Type ComponentType { get; set; }
        [CanBeNull] string Namespace { get; }

        /// <summary>
        ///     Default as singleton
        /// </summary>
        LifestyleType LifestyleType { get; }
    }
}
