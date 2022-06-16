using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{

    public enum Type
    {
        Keyblade, Shield, Staff, Other
    }

    public class Weapon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}