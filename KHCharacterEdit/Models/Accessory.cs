using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class Accessory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Character> Characters{ get; set; }
    }
}