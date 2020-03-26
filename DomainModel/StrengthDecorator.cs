using Contracts.DataModel;
using DynamicCombinator.Finder;

namespace DataModel
{
    [DynamicDecorator(typeof(IWeapon), 4)]
    public class StrengthDecorator : WeaponDecoratorBase
    {
        #region Properties

        public override int MinPhysicalDamage { get => base.MinPhysicalDamage + 3; set => base.MinPhysicalDamage = value; }
        public override int MaxPhysicalDamage { get => base.MaxPhysicalDamage + 6; set => base.MaxPhysicalDamage = value; }

        #endregion

        #region Constructors

        public StrengthDecorator(IWeapon weapon) : base(weapon) { }

        #endregion
    }
}