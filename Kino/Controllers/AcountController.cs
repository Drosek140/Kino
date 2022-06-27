using Kino.dtos;
using Kino.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Controllers
{
    [Route("api/acount")]
    [ApiController]
    public class AcountController : Controller
    {
        private readonly IAcountService acountService;
        public AcountController(IAcountService acountService)
        {
            this.acountService = acountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUer([FromBody] RegisterUserDto dto)
        {
            acountService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = acountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
