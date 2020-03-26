using System;
using System.Collections.Generic;

namespace Contracts.DynamicCombinator.Engine
{
    public interface IDecoratorApplier
    {
        #region Methods

        object Decorate(object item, IEnumerable<Type> combination);

        #endregion
    }
}