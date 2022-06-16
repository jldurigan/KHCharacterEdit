using KHCharacterEdit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Type = KHCharacterEdit.Models.Type;

namespace KHCharacterEdit.DAL
{
    public class KHInitializer: DropCreateDatabaseIfModelChanges<KHContext>
    {
        protected override void Seed(KHContext context)
        {
            var weapons = new List<Weapon>
            {
                new Weapon{Name="Kingdom Key", Type=Type.Keyblade},
                new Weapon{Name="Save the Queen", Type=Type.Staff},
                new Weapon{Name="Save the King", Type=Type.Shield}
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
                new Character{Name="Sora"},
                new Character{Name="Donald"},
                new Character{Name="Goofy"}
            };

            characters.ForEach(s => context.Characters.Add(s));
            context.SaveChanges();
        }
    }
}