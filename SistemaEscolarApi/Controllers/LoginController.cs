using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaEscolarApi.DTO;
using SistemaEscolarApi.Models;
using SistemaEscolarApi.Services;
using FluentValidation;



namespace SistemaEscolarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login ([FromBody] LoginDTO loginDTO)
        {
           if (string.IsNullOrWhiteSpace(loginDTO.Username) || string.IsNullOrWhiteSpace(loginDTO.Password))
           {
            return BadRequest("Username and password are required.");
           }
           var users = List<Usuario>
           {
            new Usuario { Username = "admin", Password = "1234", Role = "Admin" }, 
            new Usuario { Username = "user", Password = "1234", Role = "User" }
           }

           var user = users.FirstOrDefault(u => 
           u.Username == loginDTO.Username && 
           u.Password == loginDTO.Password
           );

           if (user == null)
            return Unauthorized(new {message = "Invalid username or password."}); //Existe mas está errado
        
           var token = TokenService.GenerateToken(user); //Gera o token com o usuário logado
           return Ok(new {token});
        }
    }
}