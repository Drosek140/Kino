using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Entity
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Kind { get; set; }
        public DateTime Start { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
