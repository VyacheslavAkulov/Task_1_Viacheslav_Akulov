using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Genre
    {
        [Key]
        public string Name { get; set; }

        public virtual ICollection<Genre> Childs { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public Genre()
        {
            Childs = new List<Genre>();

            Games = new List<Game>();
        }
    }
}
