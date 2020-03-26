using Contracts.DynamicCombinator.Engine;
using Contracts.DynamicCombinator.Calculation;
using Contracts.DynamicCombinator.Data;
using Core;
using System;
using System.Collections.Generic;

namespace DynamicCombinator
{
    internal class CombinationMapCreator : ICombinationMapCreator
    {
        #region Fields

        private readonly IList<Type> decorators;
        private readonly ICombinatoricsCalculator calculator;

        #endregion

        #region Constructors

        public CombinationMapCreator(IList<Type> decorators, ICombinatoricsCalculator calculator)
        {
            this.decorators = decorators;
            this.calculator = calculator;
        }

        #endregion

        #region Methods

        public IRankedCombinationMap CreateMap()
        {
            var map = new RankedCombinationMap();
            calculator
                .GetCombinations(decorators)
                .ForEach(c => map.AddRanked(c));
            return map;
        }

        public IRankedCombinationMap CreateMap(Func<IList<Type>, bool> criteria)
        {
            var map = new RankedCombinationMap();
            calculator
                .GetCombinations(decorators, criteria)
                .ForEach(c => map.AddRanked(c));
            return map;
        }

        #endregion
    }
}