using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class ArmorSlot
    {
        public int ID { get; set; }
        public int CharacterID { get; set; }
        public int ArmorID { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Armor> Armors { get; set; }
    }
}