using Kino.dtos;
using Kino.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Controllers
{
    [Route("Cinema")]
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly ICinemaService cinemaservice;

        public CinemaController(ICinemaService cinemaService) 
        {
            this.cinemaservice = cinemaService;
        }
        [HttpGet]
        public ActionResult<List<CinemaDto>> GetAll()
        {

            return Ok(cinemaservice.GetAll());
        }
        [HttpGet("{Id}")]
        public ActionResult<CinemaDto>GetById([FromRoute]int Id)
        {

            return Ok(cinemaservice.GetById(Id));
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateCinemaDto dto)
        {
            
            return Ok(cinemaservice.Create(dto));
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete([FromRoute] int Id)
        {
            cinemaservice.DeleteById(Id);
            return Ok();

        }
        [HttpPut("{Id}")]
        public ActionResult Update([FromRoute] int Id,[FromBody] UpdateCinemaDto dto)
        {
            cinemaservice.Edit(Id, dto);
            return Ok();
        }
    }
}
