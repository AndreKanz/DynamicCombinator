using Contracts.DynamicCombinator.Engine;
using Core;
using System;
using System.Collections.Generic;

namespace DynamicCombinator
{
    internal class DecoratorApplier : IDecoratorApplier
    {
        #region Methods

        public object Decorate(object item, IEnumerable<Type> combination)
        {
            if (item == null || combination == null)
                return null;

            combination.ForEach(d => item = Activator.CreateInstance(d, item));
            return item;
        }

        #endregion
    }
}