using Contracts.DataModel;
using DynamicCombinator.Finder;

namespace DataModel
{
    [DynamicDecorator(typeof(IWeapon), 3)]
    public class BurningDecorator : WeaponDecoratorBase
    {
        #region Properties

        public override int MinFireDamage { get => base.MinFireDamage + 2; set => base.MinFireDamage = value; }
        public override int MaxFireDamage { get => base.MaxFireDamage + 5; set => base.MaxFireDamage = value; }
        #endregion

        #region Constructors

        public BurningDecorator(IWeapon weapon) : base(weapon) {   }

        #endregion
    }
}