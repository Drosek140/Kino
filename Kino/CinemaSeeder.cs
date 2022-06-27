using Kino.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino
{
    public class CinemaSeeder
    {
        private readonly CinemaDbContext dbContext;
        public CinemaSeeder(CinemaDbContext cinemaDbContext)
        {
            dbContext = cinemaDbContext;

        }
        public void Seed()
        {
            if (dbContext.Database.CanConnect())
            {
               
                if (!dbContext.Cinemas.Any())
                {
                    var cinema = GetCinemas();
                    dbContext.Cinemas.AddRange(cinema);
                    dbContext.SaveChanges();
                }
                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.Roles.AddRange(roles);
                    dbContext.SaveChanges();
                }
            }
        }
        private List<Cinema> GetCinemas()
        {
            List<Cinema> cinemas = new List<Cinema>()
            {
                new Cinema()
                {
                    Name = "Cinema City",
                    Description = "W środku miasta",
                    NumberOfRoom = 23,
                    Email = "CienmaCity@gmail.com",
                    Telephone = "234567567",
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Dąbrowskiego",
                        Number = "332a",
                        PostalCode = "32-050"

                    },
                    Film = new List<Film>()
                    {
                        new Film()
                        {
                            Name = "Wścieklły Pieterwas",
                            Description = "Krótki opis filmu nie wiem",
                            Kind = "Horror",
                            Start = DateTime.Parse("2022-07-30 22:12 PM"),
                        },
                         new Film()
                        {
                            Name = "Jakiś nowy Film",
                            Description = "Ten film jest wspaniały",
                            Kind = "Dramat",
                            Start = DateTime.Parse("2022-07-20 20:12 PM"),
                        }
                    }
                }
            };
            return cinemas;
        }
        private List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User",

                } ,
                new Role()
                {
                    Name = "Manager",

                }
            };
            return roles;
        }
    }
}
