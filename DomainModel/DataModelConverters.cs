using Contracts.DataModel;
using Core.Patterns;
using Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataModel
{
    public class DataModelConverters : MonoStateFactoryBase<Type, JsonConverter>
    {
        #region Fields

        private static readonly IDictionary<Type, Func<JsonConverter>> Converters =
            new Dictionary<Type, Func<JsonConverter>>
            {
                { typeof(IWeapon), () => new JConverter<IWeapon, Sword>() }
            };

        #endregion

        #region Properties

        protected override IDictionary<Type, Func<JsonConverter>> ConstructorMap => Converters;

        #endregion
    }
}