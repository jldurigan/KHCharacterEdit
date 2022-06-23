using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{

    public enum WeaponType
    {
        Keyblade, Staff, Shield
    }

    public class Weapon
    {
        public int ID { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public int Strength { get; set; } = 0;
        public int Magic { get; set; } = 0;
        public int? AbilityID { get; set; }
        public WeaponType WeaponType { get; set; }

        public virtual Ability Ability { get; set; }
    }
}