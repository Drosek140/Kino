using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.dtos
{
    public class CinemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public List<FilmDto> Film { get; set; }
    }
}
