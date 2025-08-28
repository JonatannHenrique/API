using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;
namespace Pizzaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CadastroController(AppDbContext context) { _context = context; }
        [HttpGet]
        public IActionResult Get() => Ok(_context.Clientes.ToList());
        [HttpPost]
        public IActionResult GetCadastrarUsuario([FromBody] Cadastro clientes)
        {
            if (_context.Clientes.Any(c => c.Email == clientes.Email))
            {               
                return BadRequest("Email Já está sendo usado. ");
            }


            _context.Clientes.Add(clientes);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Cadastro Feito"
            });
        }


    }
}
