using Contracts.DataModel;
using DataModel;
using DynamicCombinator.Finder;

namespace DerRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = new DecoratorFinder("DataModel").FindDecorators<IWeapon>();
            var generator = WeaponDropGeneratorFactory.CreateDropGenerator(types);
            //adjust path
            var gen2 = WeaponDropGeneratorFactory.CreateDropGenerator("map.json");
            var decorated = gen2.Generate(GetSword(), 6, 25);
        }

        private static IWeapon GetSword()
        {
            return new Sword()
            {
                AttackChance = 0.8,
                ItemLevel = 1,
                MaxFireDamage = 0,
                MaxIceDamage = 0,
                MaxPhysicalDamage = 7,
                MaxPoisonDamage = 0,
                MinFireDamage = 0,
                MinIceDamage = 0,
                MinPhysicalDamage = 2,
                MinPoisonDamage = 0,
                Name = "Shortsword",
                AttackSpeed = 0.3,
            };
        }
    }
}