using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Pizzaria.Controllers;
using Pizzaria.Models;

namespace Pizzaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerLogin : ControllerBase
    {
        private readonly AppDbContext _context;
        public ControllerLogin(AppDbContext context) { _context = context; }

        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            var cliente = _context.Clientes.FirstOrDefault(c =>
                c.Email == login.Email && c.Senha == login.Senha);

            if (cliente == null)
                return Unauthorized("Email ou senha incorretos.");

            //_context.Clientes.Add(cliente);
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
