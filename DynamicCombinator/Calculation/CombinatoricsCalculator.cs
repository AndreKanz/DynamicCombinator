using Contracts.DynamicCombinator.Calculation;
using System;
using System.Collections.Generic;

namespace DynamicCombinator.Calculation
{
    internal class CombinatoricsCalculator : ICombinatoricsCalculator
    {
        #region Methods

        public IEnumerable<IList<T>> GetCombinations<T>(IList<T> elements, Func<IList<T>, bool> isValid)
        {
            for (var i = 0; i < (int)Math.Pow(2, elements.Count); ++i)
            {
                var combination = GetCombination(i, elements);
                if (isValid(combination))
                    yield return combination;
            }
        }

        public IEnumerable<IList<T>> GetCombinations<T>(IList<T> elements)
        {
            for (var i = 0; i < (int)Math.Pow(2, elements.Count); ++i)
                yield return GetCombination(i, elements);
        }

        private static IList<T> GetCombination<T>(int i, IList<T> elements)
        {
            var combination = new List<T>();
            for (var j = 0; j < elements.Count; ++j)
            {
                var pos = 1 << j;
                if ((pos & i) == pos)
                    combination.Add(elements[j]);
            }
            return combination;
        }

        #endregion
    }
}