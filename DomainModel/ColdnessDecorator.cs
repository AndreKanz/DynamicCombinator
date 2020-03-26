using Contracts.DataModel;
using DynamicCombinator.Finder;

namespace DataModel
{
    [DynamicDecorator(typeof(IWeapon), 5)]
    public class ColdnessDecorator : WeaponDecoratorBase
    {
        #region Properties

        public override int MinIceDamage { get => base.MinIceDamage + 2; set => base.MinIceDamage = value; }
        public override int MaxIceDamage { get => base.MaxIceDamage + 5; set => base.MaxIceDamage = value; }
        #endregion

        #region Constructors

        public ColdnessDecorator(IWeapon weapon) : base(weapon) {   }

        #endregion
    }
}
