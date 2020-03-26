using System;

namespace Contracts.Core.Serialization
{
    public interface ISerializer
    {
        #region Methods

        void Serialize<T>(T obj, string path);
        T Deserialize<T>(string path);

        void Serialize(object obj, string path);
        object Deserialize(string path, Type type);

        #endregion
    }
}