using Contracts.DataModel;
using DynamicCombinator.Finder;

namespace DataModel
{
    [DynamicDecorator(typeof(IWeapon), 7)]
    public class VenomDecorator : WeaponDecoratorBase
    {
        #region Properties

        public override int MinPoisonDamage { get => base.MinPoisonDamage + 2; set => base.MinPoisonDamage = value; }
        public override int MaxPoisonDamage { get => base.MaxPoisonDamage + 16; set => base.MaxPoisonDamage = value; }
        #endregion

        #region Constructors

        public VenomDecorator(IWeapon weapon) : base(weapon) { }

        #endregion
    }
}