using Kino.dtos;
using Kino.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Services
{
    public interface IAcountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
    }
    public class AcountService:IAcountService
    {
        private readonly CinemaDbContext dbcontext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly AutenticationSettings autenticationSettings;
        public AcountService(CinemaDbContext dbContext, IPasswordHasher<User> passwordHasher, AutenticationSettings autenticationSettings)
        {
            dbcontext = dbContext;
           this.passwordHasher = passwordHasher;
            this.autenticationSettings = autenticationSettings;
        }
     

        public void RegisterUser(RegisterUserDto dto)
        {

            var newUser = new User()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PassHash = dto.Pass,
                RoleId = dto.RoleId
            };
            var hashedPassword = passwordHasher.HashPassword(newUser, dto.Pass);
           
            newUser.PassHash = hashedPassword;
            dbcontext.Users.Add(newUser);
            dbcontext.SaveChanges();
        }
        public string GenerateJwt(LoginDto dto)
        {
            var user = dbcontext.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == dto.Email);
            if (user is null)
            {
                throw new Exception("invalid username or password");
            }
                var result = passwordHasher.VerifyHashedPassword(user, user.PassHash, dto.Pass);
                if (result == PasswordVerificationResult.Failed)
                {
                    throw new Exception("invalid username or password");
                }
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,$"{user.FirstName}{user.LastName}"),
                    new Claim(ClaimTypes.Role,$"{user.Role.Name}"),

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(autenticationSettings.JwtKey));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(autenticationSettings.JwtExpireDays);
                var token = new JwtSecurityToken(autenticationSettings.JwtIssuer,
                    autenticationSettings.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: cred);

                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(token);
            }
        
    }
}
