using AutoMapper;
using Kino.dtos;
using Kino.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Cinema, CinemaDto>().ForMember(t => t.City, c => c.MapFrom(t => t.Address.City))
                .ForMember(t => t.Street, c => c.MapFrom(t => t.Address.Street))
                .ForMember(t => t.PostalCode, c => c.MapFrom(t => t.Address.PostalCode))
                .ForMember(t => t.Number, c => c.MapFrom(t => t.Address.Number));
            CreateMap<Film, FilmDto>();
            CreateMap<CreateCinemaDto,Cinema>().ForMember(t=>t.Address,a=>a.MapFrom(t=>new Address(){City = t.City,PostalCode=t.PostalCode,Street=t.Street,Number=t.Number }));
            CreateMap<CreateFilmDto, FilmDto>();
        }
    }
}
