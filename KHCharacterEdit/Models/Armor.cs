using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class Armor
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int Strength { get; set; } = 0;
        public int Defense { get; set; } = 0;
        public int FireResistance { get; set; } = 0;
        public int IceResistance { get; set; } = 0;
        public int ThunderResistance { get; set; } = 0;
        public int DarkResistance { get; set; } = 0;

        public virtual ICollection<Character> Characters { get; set; }
    }
}