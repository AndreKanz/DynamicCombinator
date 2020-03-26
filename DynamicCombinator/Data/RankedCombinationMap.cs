using Contracts.DynamicCombinator.Data;
using Core;
using DynamicCombinator.Finder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicCombinator
{
    internal class RankedCombinationMap : SortedDictionary<int, IList<IList<Type>>>, IRankedCombinationMap
    {
        #region Methods

        public IDictionary<int, IList<IList<Type>>> Filter(Func<KeyValuePair<int, IList<IList<Type>>>, bool> criteria)
        {
            return this
                .Where(criteria)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public void AddRanked(IList<Type> combination)
        {
            var rank = CalculateRank(combination);
            if (rank < 1)
                return;

            if (ContainsKey(rank))
                this[rank].Add(combination);
            else
                Add(rank, new List<IList<Type>> { combination });
        }

        private static int CalculateRank(IList<Type> combination)
        {
            return (from item in combination
                    let attribute = item.GetAttribute<DynamicDecoratorAttribute>()
                    where attribute != null
                    select attribute.Rank)
                   .Sum();
        }

        #endregion
    }
}