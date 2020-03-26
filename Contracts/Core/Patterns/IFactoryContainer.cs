namespace Contracts.Core.Patterns
{
    public interface IFactoryContainer<TKey, TValue> : IAbstractFactory<TKey, TValue>
    {
        #region Methods

        void AddFactory(IAbstractFactory<TKey, TValue> factory);

        #endregion
    }
}