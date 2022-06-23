using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class Character
    {
        public int ID { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public int ArmorSlots { get; set; } = 1;
        public int AccessorySlots { get; set; } = 1;
        public int WeaponID { get; set; }
        public int AbilitySlots { get; set; } = 1;

        public virtual WeaponType WeaponType { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual ICollection<Armor> Armors { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }
    }
}