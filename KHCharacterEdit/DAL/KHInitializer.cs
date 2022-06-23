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
                new Ability{Name="Damage Control", AbilityPoints=5, Description="Halves the damage you take when at critical health."},
                new Ability{Name="Draw", AbilityPoints=3, Description="Draws and obtains nearby orbs."},
                new Ability{Name="Air Combo Plus", AbilityPoints=1, Description="Increases maximum combo by 1 when in midair."},
                new Ability{Name="MP Rage", AbilityPoints=3, Description="Restores MP relative to the amount of damage taken. Equip more to increase the effect."},
                new Ability{Name="Air Combo Boost", AbilityPoints=4, Description="Increases the damage of the finishing move in the air relative to the number of hits in the combo."}
            };

            abilities.ForEach(s => context.Abilities.Add(s));
            context.SaveChanges();

            var weapons = new List<Weapon>
            {
                new Weapon{Name="Kingdom Key", Strength=3, Magic=1, WeaponType=WeaponType.Keyblade, Ability=abilities[0]},
                new Weapon{Name="Star Seeker", Strength=3, Magic=1, WeaponType=WeaponType.Keyblade, Ability=abilities[2]},
                new Weapon{Name="Hidden Dragon", Strength=2, Magic=2, WeaponType=WeaponType.Keyblade, Ability=abilities[3]},
                new Weapon{Name="Hero's Crest", Strength=4, WeaponType=WeaponType.Keyblade, Ability=abilities[4]},
                new Weapon{Name="Mage Staff", Strength=1, Magic=1, WeaponType=WeaponType.Staff},
                new Weapon{Name="Hammer Staff", Strength=2, Magic=1, WeaponType=WeaponType.Staff},
                new Weapon{Name="Comet Staff", Strength=2, Magic=2, WeaponType=WeaponType.Staff},
                new Weapon{Name="Victory Bell", Strength=3, Magic=2, WeaponType=WeaponType.Staff},
                new Weapon{Name="Knight's Shield", Strength=1, WeaponType=WeaponType.Shield},
                new Weapon{Name="Adamant Shield", Strength=2, WeaponType=WeaponType.Shield},
                new Weapon{Name="Falling Star", Strength=3, WeaponType=WeaponType.Shield},
                new Weapon{Name="Chain Gear", Strength=3, WeaponType=WeaponType.Shield}
            };

            weapons.ForEach(s => context.Weapons.Add(s));
            context.SaveChanges();

            List<Armor> armors = new List<Armor>
            {
                new Armor{Name="Abas Chain", FireResistance=20, IceResistance=20, ThunderResistance=20},
                new Armor{Name="Acrisius", Defense=3, FireResistance=20, IceResistance=20, ThunderResistance=20},
                new Armor{Name="Acrisius+", Defense=3, FireResistance=25, IceResistance=25, ThunderResistance=25},
                new Armor{Name="Aegis Chain", Defense=2, FireResistance=20, IceResistance=20, ThunderResistance=20},
                new Armor{Name="Blizzard Armlet", Defense=1, IceResistance=20}
            };

            armors.ForEach(s => context.Armors.Add(s));
            context.SaveChanges();

            var accessories = new List<Accessory>
            {
                new Accessory{Name="Ability Ring", AbilityPoints=1},
                new Accessory{Name="Aquamarine Ring", AbilityPoints=1, Strength=1},
                new Accessory{Name="Cosmic Arts", AbilityPoints=7, Strength=1, Magic=1},
                new Accessory{Name="Cosmic Ring", AbilityPoints=8},
                new Accessory{Name="Draw Ring", Ability=abilities[1]}
            };

            accessories.ForEach(s => context.Accessories.Add(s));
            context.SaveChanges();

            var characters = new List<Character>
            {
                new Character{Name="Sora", Weapon=weapons[0], WeaponType=WeaponType.Keyblade, Armors=new List<Armor>{armors[0]} },
                new Character{Name="Donald", Weapon=weapons[4], WeaponType=WeaponType.Staff},
                new Character{Name="Goofy", Weapon=weapons[8], WeaponType=WeaponType.Shield}
            };

            characters.ForEach(s => context.Characters.Add(s));
            context.SaveChanges();
        }
    }
}