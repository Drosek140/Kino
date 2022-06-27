using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.dtos
{
    public class RegisterUserDto
    {
        
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
