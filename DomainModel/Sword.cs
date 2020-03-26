using Contracts.DataModel;
using System.Collections.Generic;

namespace DataModel
{
    public class Sword : IWeapon
    {
        #region Properties

        public string Name { get; set; }
        public IList<string> Attributes { get; set; }
        public int ItemLevel { get; set; }
        public double AttackSpeed { get; set; }
        public double AttackChance { get; set; }
        public int MinPhysicalDamage { get; set; }
        public int MaxPhysicalDamage { get; set; }
        public int MinFireDamage { get; set; }
        public int MaxFireDamage { get; set; }
        public int MinIceDamage { get; set; }
        public int MaxIceDamage { get; set; }
        public int MinPoisonDamage { get; set; }
        public int MaxPoisonDamage { get; set; }

        #endregion
    }
}