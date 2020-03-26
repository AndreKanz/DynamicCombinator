using System;
using System.Collections.Generic;

namespace Contracts.DynamicCombinator.Finder
{
    public interface IDecoratorFinder
    {
        #region Methods

        IList<Type> FindDecorators<TItem>();

        #endregion
    }
}