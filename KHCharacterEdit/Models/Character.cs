using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? WeaponID { get; set; }

        public virtual Weapon Weapon { get; set; }
        public virtual ICollection<Armor> Armors { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }
    }
}