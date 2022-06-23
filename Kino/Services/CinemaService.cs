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
    public interface ICinemaService
    {
        int Create(CreateCinemaDto dto);
        List<CinemaDto> GetAll();
        CinemaDto GetById(int Id);
        void DeleteById(int Id);
        void Edit(int Id, UpdateCinemaDto dto);


    }
    public class CinemaService : ICinemaService
    {
        private readonly IMapper mapper;
        private readonly CinemaDbContext cinemaDbContext;
        public CinemaService(CinemaDbContext cinemaDbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.cinemaDbContext = cinemaDbContext;
        }
        public int Create(CreateCinemaDto dto)
        {
            var cinema = mapper.Map<Cinema>(dto);
            cinemaDbContext.Cinemas.Add(cinema);
            cinemaDbContext.SaveChanges();
            return cinema.Id;
        }

        public void DeleteById(int Id)
        {
            var cinema = cinemaDbContext.Cinemas.Include(t=>t.Address).Include(t=>t.Film).FirstOrDefault(t=>t.Id==Id);
            if(cinema == null)
            {
                throw new Exception("take kino nie istnieje");
            }
            else
            {
                cinemaDbContext.Cinemas.Remove(cinema);
                cinemaDbContext.SaveChanges();
            }     
            
        }

        public void Edit(int Id, UpdateCinemaDto dto)
        {
            var cinema = cinemaDbContext.Cinemas.Include(t => t.Address).Include(t => t.Film).FirstOrDefault(t => t.Id == Id);
            if (cinema == null)
            {
                throw new Exception("take kino nie istnieje");
            }
            else
            {
                cinema.Name = dto.Name;
                cinema.Telephone = dto.Telephone;
                cinema.Description = dto.Description;
                cinema.Address.City = dto.City;
                cinema.Address.Street = dto.Street;
                cinema.Address.PostalCode = dto.PostalCode;
                cinema.Address.Number = dto.Number;
               
                cinemaDbContext.SaveChanges();
            }
            
        }

        public List<CinemaDto> GetAll()
        {
            var cinemas = cinemaDbContext.Cinemas.Include(t => t.Address).Include(t => t.Film).ToList();
            var cinemasdto = mapper.Map<List<CinemaDto>>(cinemas);
            return cinemasdto;
           
        }

        public CinemaDto GetById(int Id)
        {
            var cinema = cinemaDbContext.Cinemas.Include(t => t.Address).Include(t => t.Film).FirstOrDefault(t => t.Id == Id);
            if (cinema == null)
            {
                throw new Exception("take kino nie istnieje");
            }
            else
            {
                return mapper.Map<CinemaDto>(cinema);

                
            }
            
        }
    }
}
