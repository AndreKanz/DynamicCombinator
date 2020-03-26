using Contracts.DataModel;
using DynamicCombinator.Finder;

namespace DataModel
{
    [DynamicDecorator(typeof(IWeapon), 5)]
    public class PoisonDecorator : WeaponDecoratorBase
    {
        #region Properties

        public override int MinPoisonDamage { get => base.MinPoisonDamage + 1; set => base.MinPoisonDamage = value; }
        public override int MaxPoisonDamage { get => base.MaxPoisonDamage + 8; set => base.MaxPoisonDamage = value; }
        #endregion

        #region Constructors

        public PoisonDecorator(IWeapon weapon) : base(weapon) { }

        #endregion
    }
}
