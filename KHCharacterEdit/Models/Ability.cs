using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class Ability
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AbilityPoints { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}