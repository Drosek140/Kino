using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Entity
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfRoom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int AdresId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Film> Film { get; set; }

    }
}
