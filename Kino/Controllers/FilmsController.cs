using Kino.dtos;
using Kino.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Controllers
{
    [Route("Cinema/{cinemaId}/Film")]
    [ApiController]
          
       public class FilmController : Controller
        {
            private readonly IFilmService filmservice;

            public FilmController(IFilmService filmService)
            {
                this.filmservice = filmService;
            }
            [HttpGet]
            public ActionResult<FilmDto> GetAll([FromRoute] int cinemaId)
            {

                return Ok(filmservice.GetAll(cinemaId));
            }
            [HttpGet("{Id}")]
            public ActionResult<FilmDto> GetById([FromRoute] int Id, int cinemaId)
            {

                return Ok(filmservice.GetById(Id, cinemaId));
            }
            [HttpPost]
            public ActionResult Create([FromBody] CreateFilmDto dto,[FromRoute] int cinemaId)
            {

                return Ok(filmservice.Create(dto,cinemaId));
            }
            [HttpDelete("{Id}")]
            public ActionResult Delete([FromRoute] int Id, int cinemaId)
            {
                filmservice.DeleteById(Id,cinemaId);
                return Ok();

            }
            [HttpPut("{Id}")]
            public ActionResult Update([FromRoute] int Id, [FromBody] UpdateFilmDto dto, int cinemaId)
            {
                filmservice.Edit(Id, dto, cinemaId);
                return Ok();
            }
        }
    
}
