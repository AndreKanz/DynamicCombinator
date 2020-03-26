using Contracts.Core.Serialization;
using Contracts.DataModel;
using Contracts.DynamicCombinator.DropGeneration;
using Core.Patterns;
using Core.Serialization;
using DataModel;
using DynamicCombinator;
using DynamicCombinator.DropGeneration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DerRunner
{
    public static class WeaponDropGeneratorFactory
    {
        #region Constants

        private const string Extension = ".json";

        #endregion

        #region Fields

        private static readonly ISerializer Serializer = GetSerializer();

        #endregion

        #region Methods

        public static IDropGenerator<IWeapon> CreateDropGenerator(IList<Type> decorators)
        {
            return decorators == null 
                ?  null 
                :  DropGeneratorFactory.CreateDropGenerator<IWeapon>(decorators);
        }

        public static IDropGenerator<IWeapon> CreateDropGenerator(string path)
        {
            return IsFileNotValid(path)
                ?  null
                :  DropGeneratorFactory.CreateDropGenerator<IWeapon>(path, Serializer);
        }

        private static bool IsFileNotValid(string path)
        {
            return string.IsNullOrEmpty(path) 
                || Path.GetExtension(path) != Extension 
                || !File.Exists(path);
        }

        private static ISerializer GetSerializer()
        {
            var container = new FactoryContainer<Type, JsonConverter>();
            container.AddFactory(new DynamicCombinatorConverters());
            container.AddFactory(new DataModelConverters());
            return new JSerializer(container);
        }

        #endregion
    }
}