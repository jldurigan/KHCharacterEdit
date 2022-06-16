using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class AccessorySlot
    {
        public int ID { get; set; }
        public int CharacterID { get; set; }
        public int AccessoryID { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }
    }
}