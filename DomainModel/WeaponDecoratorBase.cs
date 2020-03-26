using Contracts.DataModel;
using System.Collections.Generic;

namespace DataModel
{
    public class WeaponDecoratorBase : IWeapon
    {
        #region Fields

        private readonly IWeapon weapon;

        #endregion

        #region Properties

        public virtual string Name { get => weapon.Name; set => weapon.Name = value; }
        public virtual IList<string> Attributes { get => weapon.Attributes; set => weapon.Attributes = value; }
        public virtual int ItemLevel { get => weapon.ItemLevel; set => weapon.ItemLevel = value; }
        public virtual double AttackSpeed { get => weapon.AttackSpeed; set => weapon.AttackSpeed = value; }
        public virtual double AttackChance { get => weapon.AttackChance; set => weapon.AttackChance = value; }
        public virtual int MinPhysicalDamage { get => weapon.MinPhysicalDamage; set => weapon.MinPhysicalDamage = value; }
        public virtual int MaxPhysicalDamage { get => weapon.MaxPhysicalDamage; set => weapon.MaxPhysicalDamage = value; }
        public virtual int MinFireDamage { get => weapon.MinFireDamage; set => weapon.MinFireDamage = value; }
        public virtual int MaxFireDamage { get => weapon.MaxFireDamage; set => weapon.MaxFireDamage = value; }
        public virtual int MinIceDamage { get => weapon.MinIceDamage; set => weapon.MinIceDamage = value; }
        public virtual int MaxIceDamage { get => weapon.MaxIceDamage; set => weapon.MaxIceDamage = value; }
        public virtual int MinPoisonDamage { get => weapon.MinPoisonDamage; set => weapon.MinPoisonDamage = value; }
        public virtual int MaxPoisonDamage { get => weapon.MaxPoisonDamage; set => weapon.MaxPoisonDamage = value; }

        #endregion

        #region Constructors

        public WeaponDecoratorBase(IWeapon weapon)
        {
            this.weapon = weapon;
            if (this.weapon.Attributes == null)
                this.weapon.Attributes = new List<string> { GetType().Name };
            else
                this.weapon.Attributes.Add(GetType().Name);
        }

        #endregion
    }
}