using System;
using System.Collections.Generic;

namespace Contracts.DynamicCombinator.Data
{
    public interface IRankedCombinationMap
    {
        #region Methods

        IDictionary<int, IList<IList<Type>>> Filter(Func<KeyValuePair<int, IList<IList<Type>>>, bool> criteria);
        void AddRanked(IList<Type> combination);

        #endregion
    }
}