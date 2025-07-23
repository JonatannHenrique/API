using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Pizzaria.Controllers;
namespace Pizzaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerCadastro : ControllerBase
    {
        private readonly AppDbContext _context;
        public ControllerCadastro(AppDbContext context) { _context = context; }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Clientes.ToList());

        [HttpPost]
        public IActionResult Post([FromBody] Cadastro cliente)
        {
            if (_context.Clientes.Any(c => c.Email == cliente.Email))
                return BadRequest("Email já cadastrado.");

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            
            return Ok(new
            {
                message = "Cadastro bem sucedido",
                cliente.Id,
                cliente.Nome,
                cliente.Email
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
    }
}
