using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public Game()
        {
            Comments = new List<Comment>();

            Genres = new List<Genre>();

            Platforms = new List<PlatformType>();
        }

        [Key]
        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<PlatformType> Platforms { get; set; }




    }
}
