using Contracts.DynamicCombinator.Data;
using Contracts.DynamicCombinator.DropGeneration;
using Contracts.DynamicCombinator.Engine;
using Core;
using System;
using System.Collections.Generic;

namespace DynamicCombinator.DropGeneration
{
    internal class DropGenerator<TItem> : IDropGenerator<TItem>
    {
        #region Fields

        private readonly IRankedCombinationMap map;
        private readonly IDecoratorApplier applier;

        #endregion

        #region Constructors

        internal DropGenerator(IRankedCombinationMap map, IDecoratorApplier applier)
        {
            this.map = map;
            this.applier = applier;
        }

        #endregion

        #region Methods

        public TItem Generate(TItem item, int minLevel, int maxLevel)
        {
            var combination = GetCombination(minLevel, maxLevel);
            return (TItem)applier.Decorate(item, combination);
        }

        private IList<Type> GetCombination(int minLevel, int maxLevel)
        {
            return map
                .Filter(c => c.Key.IsBetween(minLevel, maxLevel))
                .RandomValue()
                .RandomElement();
        }

        #endregion
    }
}