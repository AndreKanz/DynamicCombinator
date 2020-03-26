using Contracts.DynamicCombinator.Data;
using Core.Patterns;
using Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DynamicCombinator
{
    public class DynamicCombinatorConverters : MonoStateFactoryBase<Type, JsonConverter>
    {
        #region Fields

        private static readonly IDictionary<Type, Func<JsonConverter>> Converters =
            new Dictionary<Type, Func<JsonConverter>>
            {
                { typeof(IRankedCombinationMap), () => new JConverter<IRankedCombinationMap, RankedCombinationMap>() }
            };

        #endregion

        #region Properties

        protected override IDictionary<Type, Func<JsonConverter>> ConstructorMap => Converters;

        #endregion
    }
}