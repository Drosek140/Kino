using AutoMapper;
using Kino.dtos;
using Kino.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Services
{
    public interface IFilmService
    {
        int Create(CreateFilmDto dto, int cinemaId);
        List<FilmDto> GetAll(int cinemaId);
        FilmDto GetById(int Id, int cinemaId);
        void DeleteById(int Id, int cinemaId);
        void Edit(int Id, UpdateFilmDto dto, int cinemaId);


    }
    public class FilmsService : IFilmService
    {
        private readonly IMapper mapper;
        private readonly CinemaDbContext cinemaDbContext;
        public FilmsService(CinemaDbContext cinemaDbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.cinemaDbContext = cinemaDbContext;
        }
        public int Create(CreateFilmDto dto, int cinemaId)
        {
           
            var film = mapper.Map<Film>(dto);
            film.CinemaId = cinemaId;
            cinemaDbContext.Films.Add(film);  
            cinemaDbContext.SaveChanges();
            return film.Id;
        }

        public void DeleteById(int Id, int cinemaId)
        {
            var cinema = GetCinema(cinemaId);
            var film = cinemaDbContext.Films.FirstOrDefault(t => t.CinemaId == cinemaId);
            if (film == null)
            {
                throw new Exception("take kino nie istnieje");
            }
            else
            {
                cinemaDbContext.Films.Remove(film);
                cinemaDbContext.SaveChanges();
            }

        }

        public void Edit(int Id, UpdateFilmDto dto, int cinemaId)
        {
            var cinema = GetCinema(cinemaId);
            var film = cinemaDbContext.Films.FirstOrDefault(t => t.CinemaId == cinemaId);
            if (film == null|| film.Id!=Id)
            {
                throw new Exception("take kino nie istnieje");
            }
            else
            {
                film.Name = dto.Name;
                film.Description = dto.Description;
                film.Kind = dto.Kind;
                film.Start = dto.Start;
                cinemaDbContext.SaveChanges();
            }

        }

        public List<FilmDto> GetAll(int cinemaId)
        {
            var cinema = GetCinema(cinemaId);
           
            var filmsdto = mapper.Map<List<FilmDto>>(cinema.Film);
            return filmsdto;

        }

        public FilmDto GetById(int Id, int cinemaId)
        {
            var cinema = GetCinema(cinemaId);
            var film = cinemaDbContext.Films.FirstOrDefault(t => t.CinemaId == cinemaId);
            if (film == null|| film.CinemaId!=cinemaId)
            {
                throw new Exception("take kino nie istnieje");
            }
            else
            {
                return mapper.Map<FilmDto>(film);


            }

        }
        private Cinema GetCinema(int cinemaId)
        {
           var cinema = cinemaDbContext.Cinemas.Include(t => t.Film).FirstOrDefault(t=>t.Id==cinemaId);
            if (cinema == null)
            {
                throw new Exception("take kino nie istnieje");
            }
            else
            {
                return cinema;
            }
        }

    }
}
