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

        public virtual ICollection<ArmorSlot> ArmorSlots { get; set; }
        public virtual ICollection<AccessorySlot> AccessorySlots { get; set; }
    }
}