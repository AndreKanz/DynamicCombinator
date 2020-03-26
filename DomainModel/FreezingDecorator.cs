using Contracts.DataModel;
using DynamicCombinator.Finder;

namespace DataModel
{
    [DynamicDecorator(typeof(IWeapon), 3)]
    public class FreezingDecorator : WeaponDecoratorBase
    {
        #region Properties

        public override int MinIceDamage { get => base.MinIceDamage + 1; set => base.MinIceDamage = value; }
        public override int MaxIceDamage { get => base.MaxIceDamage + 3; set => base.MaxIceDamage = value; }
        #endregion

        #region Constructors

        public FreezingDecorator(IWeapon weapon) : base(weapon) {   }

        #endregion
    }
}