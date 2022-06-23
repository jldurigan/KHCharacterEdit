using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KHCharacterEdit.Models
{
    public class Accessory
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int AbilityPoints { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int Magic { get; set; } = 0;
        public int? AbilityID { get; set; }

        public virtual Ability Ability { get; set; }
        public virtual ICollection<Character> Characters{ get; set; }
    }
}