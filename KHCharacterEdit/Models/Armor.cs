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
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int FireResistance { get; set; }
        public int IceResistance { get; set; }
        public int ThunderResistance { get; set; }
        public int DarkResistance { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}