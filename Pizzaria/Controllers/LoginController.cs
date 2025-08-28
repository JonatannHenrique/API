using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;

namespace Pizzaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LoginController(AppDbContext context) { _context = context; }


        [HttpGet("Login")]
        public IActionResult BuscarLogin(string Email, string Senha)
        { 
            var usuarios = _context.Clientes
                .FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
            if (usuarios == null)
                {
                return BadRequest($"o Email ou a senha estão incorretas ");
            }
            return Ok(usuarios);
        }
    }
}
