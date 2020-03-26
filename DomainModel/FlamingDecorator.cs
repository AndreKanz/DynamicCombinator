using Contracts.DataModel;
using DynamicCombinator.Finder;

namespace DataModel
{
    [DynamicDecorator(typeof(IWeapon), 5)]
    public class FlamingDecorator : WeaponDecoratorBase
    {
        #region Properties

        public override int MinFireDamage { get => base.MinFireDamage + 4; set => base.MinFireDamage = value; }
        public override int MaxFireDamage { get => base.MaxFireDamage + 8; set => base.MaxFireDamage = value; }
        #endregion

        #region Constructors

        public FlamingDecorator(IWeapon weapon) : base(weapon) {   }

        #endregion
    }
}