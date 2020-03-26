using Contracts.DynamicCombinator.Data;
using System;
using System.Collections.Generic;

namespace Contracts.DynamicCombinator.Engine
{
    public interface ICombinationMapCreator
    {
        #region Methods

        IRankedCombinationMap CreateMap();
        IRankedCombinationMap CreateMap(Func<IList<Type>, bool> criteria);

        #endregion
    }
}