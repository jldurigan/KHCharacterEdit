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
                new Weapon{Name="Star Seeker", WeaponType=WeaponType.Keyblade},
                new Weapon{Name="Hidden Dragon", WeaponType=WeaponType.Keyblade},
                new Weapon{Name="Hero's Crest", WeaponType=WeaponType.Keyblade},
                new Weapon{Name="Mage Staff", WeaponType=WeaponType.Staff},
                new Weapon{Name="Hammer Staff", WeaponType=WeaponType.Staff},
                new Weapon{Name="Comet Staff", WeaponType=WeaponType.Staff},
                new Weapon{Name="Victory Bell", WeaponType=WeaponType.Staff},
                new Weapon{Name="Knight's Shield", WeaponType=WeaponType.Shield},
                new Weapon{Name="Adamant Shield", WeaponType=WeaponType.Shield},
                new Weapon{Name="Falling Star", WeaponType=WeaponType.Shield},
                new Weapon{Name="Chain Gear", WeaponType=WeaponType.Shield}
            };

            weapons.ForEach(s => context.Weapons.Add(s));
            context.SaveChanges();

            var armors = new List<Armor>
            {
                new Armor{Name="Abas Chain"},
                new Armor{Name="Acrisius"},
                new Armor{Name="Acrisius+"},
                new Armor{Name="Aegis Chain"},
                new Armor{Name="Blizzard Armlet"}
            };

            armors.ForEach(s => context.Armors.Add(s));
            context.SaveChanges();

            var accessories = new List<Accessory>
            {
                new Accessory{Name="Ability Ring"},
                new Accessory{Name="Aquamarine Ring"},
                new Accessory{Name="Cosmic Arts"},
                new Accessory{Name="Cosmic Ring"},
                new Accessory{Name="Draw Ring"}
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