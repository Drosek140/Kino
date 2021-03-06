using Kino.dtos;
using Kino.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Controllers
{
    [Route("Cinema")]
    [ApiController]
    [Authorize]
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
        [AllowAnonymous]
        public ActionResult<CinemaDto>GetById([FromRoute]int Id)
        {

            return Ok(cinemaservice.GetById(Id));
        }
        [HttpPost]      
        [Authorize(Roles = "Manager")]
        public ActionResult Create([FromBody] CreateCinemaDto dto)
        {
            
            return Ok(cinemaservice.Create(dto));
        }
        [HttpDelete("{Id}")]
        [Authorize(Roles = "Manager")]
        public ActionResult Delete([FromRoute] int Id)
        {
            cinemaservice.DeleteById(Id);
            return Ok();

        }
        [HttpPut("{Id}")]
        [Authorize(Roles = "Manager")]
        public ActionResult Update([FromRoute] int Id,[FromBody] UpdateCinemaDto dto)
        {
            cinemaservice.Edit(Id, dto);
            return Ok();
        }
    }
}
