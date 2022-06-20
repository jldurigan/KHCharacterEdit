using KHCharacterEdit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.DAL
{
    public class KHInitializer: DropCreateDatabaseIfModelChanges<KHContext>
    {

        //public override void InitializeDatabase(KHContext context)
        //{
        //    context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
        //        , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

        //    base.InitializeDatabase(context);
        //}

        protected override void Seed(KHContext context)
        {
            var abilities = new List<Ability>
            {
                new Ability{Name="Draw", AbilityPoints=3, Description="Draws and obtains nearby orbs."},
                new Ability{Name="Jackpot", AbilityPoints=4, Description="Increase drop rate of munny, HP and MP orbs. Equip the whole party to further increase the drop rate."},
                new Ability{Name="Lucky Lucky!", AbilityPoints=5, Description="Will bring luck by increasing the drop rate of items. Equip whole party to further increase the drop rate."},
                new Ability{Name="Once More", AbilityPoints=4, Description="Ensure 1 HP remains after taking damage from a combo."},
                new Ability{Name="Second Chance", AbilityPoints=4, Description="Ensure 1 HP remains after taking massive damage."}
            };

            abilities.ForEach(s => context.Abilities.Add(s));
            context.SaveChanges();

            var weapons = new List<Weapon>
            {
                new Weapon{Name="Kingdom Key", Strength=3, Magic=1, WeaponType=WeaponType.Keyblade},
                new Weapon{Name="Star Seeker", Strength=3, Magic=1, WeaponType=WeaponType.Keyblade},
                new Weapon{Name="Hidden Dragon", Strength=2, Magic=2, WeaponType=WeaponType.Keyblade},
                new Weapon{Name="Hero's Crest", Strength=4, Magic=0, WeaponType=WeaponType.Keyblade},
                new Weapon{Name="Mage Staff", Strength=1, Magic=1, WeaponType=WeaponType.Staff},
                new Weapon{Name="Hammer Staff", Strength=2, Magic=1, WeaponType=WeaponType.Staff},
                new Weapon{Name="Comet Staff", Strength=2, Magic=2, WeaponType=WeaponType.Staff},
                new Weapon{Name="Victory Bell", Strength=3, Magic=2, WeaponType=WeaponType.Staff},
                new Weapon{Name="Knight's Shield", Strength=1, Magic=0, WeaponType=WeaponType.Shield},
                new Weapon{Name="Adamant Shield", Strength=2, Magic=0, WeaponType=WeaponType.Shield},
                new Weapon{Name="Falling Star", Strength=3, Magic=0, WeaponType=WeaponType.Shield},
                new Weapon{Name="Chain Gear", Strength=3, Magic=0, WeaponType=WeaponType.Shield}
            };

            weapons.ForEach(s => context.Weapons.Add(s));
            context.SaveChanges();

            var armors = new List<Armor>
            {
                new Armor{Name="Abas Chain", Strength=0, Defense=0, FireResistance=20, IceResistance=20, ThunderResistance=20, DarkResistance=0},
                new Armor{Name="Acrisius", Strength=0, Defense=3, FireResistance=20, IceResistance=20, ThunderResistance=20, DarkResistance=0},
                new Armor{Name="Acrisius+", Strength=0, Defense=3, FireResistance=25, IceResistance=25, ThunderResistance=25, DarkResistance=0},
                new Armor{Name="Aegis Chain", Strength=0, Defense=2, FireResistance=20, IceResistance=20, ThunderResistance=20, DarkResistance=0},
                new Armor{Name="Blizzard Armlet", Strength=0, Defense=1, FireResistance=0, IceResistance=20, ThunderResistance=0, DarkResistance=0}
            };

            armors.ForEach(s => context.Armors.Add(s));
            context.SaveChanges();

            var accessories = new List<Accessory>
            {
                new Accessory{Name="Ability Ring", AbilityPoints=1, Strength=0, Magic=0},
                new Accessory{Name="Aquamarine Ring", AbilityPoints=1, Strength=1, Magic=0},
                new Accessory{Name="Cosmic Arts", AbilityPoints=7, Strength=1, Magic=1},
                new Accessory{Name="Cosmic Ring", AbilityPoints=8, Strength=0, Magic=0},
                new Accessory{Name="Draw Ring", AbilityPoints=0, Strength=0, Magic=0}
            };

            accessories.ForEach(s => context.Accessories.Add(s));
            context.SaveChanges();

            var characters = new List<Character>
            {
                new Character{Name="Sora", WeaponID=1, WeaponType=WeaponType.Keyblade},
                new Character{Name="Donald", WeaponID=5, WeaponType=WeaponType.Staff},
                new Character{Name="Goofy", WeaponID=9, WeaponType=WeaponType.Shield}
            };

            characters.ForEach(s => context.Characters.Add(s));
            context.SaveChanges();
        }
    }
}