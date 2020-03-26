using System;
using System.Collections.Generic;

namespace Contracts.DynamicCombinator.Calculation
{
    public interface ICombinatoricsCalculator
    {
        #region Methods

        IEnumerable<IList<T>> GetCombinations<T>(IList<T> elements);
        IEnumerable<IList<T>> GetCombinations<T>(IList<T> elements, Func<IList<T>, bool> isValid);

        #endregion
    }
}