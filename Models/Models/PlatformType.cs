using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlatformType
    {
        public PlatformType()
        {
            Games = new List<Game>();
        }

        [Key]
        public string Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
