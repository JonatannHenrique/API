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

        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            var cliente = _context.Clientes.FirstOrDefault(c =>
                c.Email == login.Email && c.Senha == login.Senha);

            if (cliente == null)
                return Unauthorized("Email ou senha incorretos.");

            _context.SaveChanges();

            return Ok(new
            {
                message = "Login bem-sucedido!",
                cliente.Email,
                cliente.Senha
            });
        }
    }

}
