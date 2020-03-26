using Contracts.Core.Patterns;
using Contracts.Core.Serialization;
using Core.Patterns;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Core.Serialization
{
    public class JSerializer : ISerializer
    {
        #region Fields

        private readonly IFactoryContainer<Type, JsonConverter> container;

        #endregion

        #region Constructors

        public JSerializer(IFactoryContainer<Type, JsonConverter> container)
        {
            this.container = container;
        }

        public JSerializer()
        {
            container = new FactoryContainer<Type, JsonConverter>();
        }

        #endregion

        #region Methods

        public void AddFactory(IAbstractFactory<Type, JsonConverter> converters)
        {
            container.AddFactory(converters);
        }

        public void Serialize<T>(T obj, string path)
        {
            using (var file = File.CreateText(path))
            {
                var serializer = JsonSerializer.Create(GetSettings());
                serializer.Serialize(file, obj);
            }
        }

        public  T Deserialize<T>(string path)
        {
            using (var file = File.OpenText(path))
            {
                var serializer = JsonSerializer.Create(GetSettings(typeof(T)));
                return (T)serializer.Deserialize(file, typeof(T));
            }
        }

        public void Serialize(object obj, string path)
        {
            using (var file = File.CreateText(path))
            {
                var serializer = JsonSerializer.Create(GetSettings());
                serializer.Serialize(file, obj);
            }
        }

        public object Deserialize(string path, Type type)
        {
            using (var file = File.OpenText(path))
            {
                var serializer = JsonSerializer.Create(GetSettings(type));
                return serializer.Deserialize(file, type);
            }
        }

        private static JsonSerializerSettings GetSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        private JsonSerializerSettings GetSettings(Type type)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var converter = container.CreateInstance(type);
            if (converter != null)
                settings.Converters.Add(converter);

            return settings;
        }

        #endregion
    }
}