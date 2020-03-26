using Contracts.DataModel;

namespace Contracts.DynamicCombinator.DropGeneration
{
    public interface IDropGenerator<TItem>
    {
        #region Methods

        TItem Generate(TItem item, int minLevel, int maxLevel);

        #endregion
    }
}