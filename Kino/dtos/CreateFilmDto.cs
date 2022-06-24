using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.dtos
{
    public class CreateFilmDto
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Kind { get; set; }
        public DateTime Start { get; set; }
    }
}
