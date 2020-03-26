using System.Collections.Generic;

namespace Contracts.DataModel
{
    public interface IWeapon
    {
        #region Properties

        string Name              { get; set; }
        IList<string> Attributes { get; set; }
        int ItemLevel            { get; set; }
        double AttackSpeed       { get; set; }
        double AttackChance      { get; set; }
        int MinPhysicalDamage    { get; set; }
        int MaxPhysicalDamage    { get; set; }
        int MinFireDamage        { get; set; }
        int MaxFireDamage        { get; set; }
        int MinIceDamage         { get; set; }
        int MaxIceDamage         { get; set; }
        int MinPoisonDamage      { get; set; }
        int MaxPoisonDamage     { get; set; }

        #endregion
    }
}