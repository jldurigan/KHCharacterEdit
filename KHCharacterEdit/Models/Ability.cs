using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class Ability
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int AbilityPoints { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}