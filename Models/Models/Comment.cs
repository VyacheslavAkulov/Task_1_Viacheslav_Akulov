using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public Game Game { get; set; }

        public Comment Parent { get; set; }

    }
}
