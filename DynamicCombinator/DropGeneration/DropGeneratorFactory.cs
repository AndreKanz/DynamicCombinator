using Contracts.Core.Serialization;
using Contracts.DynamicCombinator.Data;
using Contracts.DynamicCombinator.DropGeneration;
using DynamicCombinator.Calculation;
using System;
using System.Collections.Generic;

namespace DynamicCombinator.DropGeneration
{
    public class DropGeneratorFactory
    {
        #region Methods

        public static IDropGenerator<TItem> CreateDropGenerator<TItem>(IList<Type> decorators)
        {
            return new DropGenerator<TItem>(
                new CombinationMapCreator(decorators, new CombinatoricsCalculator())
                    .CreateMap(),
                new DecoratorApplier());
        }

        public static IDropGenerator<TItem> CreateDropGenerator<TItem>(string path, ISerializer serializer)
        {
            return new DropGenerator<TItem>(
                serializer.Deserialize<IRankedCombinationMap>(path),
                new DecoratorApplier());
        }

        #endregion
    }
}