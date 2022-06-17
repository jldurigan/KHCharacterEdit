using KHCharacterEdit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.DAL
{
    public class KHInitializer: DropCreateDatabaseIfModelChanges<KHContext>
    {
        protected override void Seed(KHContext context)
        {
            var weapons = new List<Weapon>
            {
                new Weapon{Name="Kingdom Key", WeaponType=WeaponType.Keyblade},
                new Weapon{Name="Save the Queen", WeaponType=WeaponType.Staff},
                new Weapon{Name="Save the King", WeaponType=WeaponType.Shield}
            };

            weapons.ForEach(s => context.Weapons.Add(s));
            context.SaveChanges();

            var armors = new List<Armor>
            {
                new Armor{Name="Acrisius"}
            };

            armors.ForEach(s => context.Armors.Add(s));
            context.SaveChanges();

            var accessories = new List<Accessory>
            {
                new Accessory{Name="Ability Ring"}
            };

            accessories.ForEach(s => context.Accessories.Add(s));
            context.SaveChanges();

            var characters = new List<Character>
            {
                new Character{Name="Sora",WeaponID=0},
                new Character{Name="Donald", WeaponID=1},
                new Character{Name="Goofy", WeaponID=2}
            };

            characters.ForEach(s => context.Characters.Add(s));
            context.SaveChanges();
        }
    }
}