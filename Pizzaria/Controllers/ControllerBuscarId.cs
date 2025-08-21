using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Models;
namespace ControllerBuscarId
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Cadastro>> GetUsuarios()
        {
            return await _context.Clientes.ToListAsync();
        }


        [HttpGet("buscar")]
        public IActionResult Buscar([FromQuery] ulong? id, [FromQuery] string? nome)
        {
            if (id != null)
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
                if (cliente == null) return NotFound($"O usuário {id} não foi encontrado");
                return Ok($"Cliente: {cliente.Nome} foi encontrado!");
            }

            if (!string.IsNullOrEmpty(nome))
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Nome == nome);
                if (cliente == null) return NotFound($"O usuário {nome} não foi encontrado");
                return Ok($"Cliente: {cliente.Nome} foi encontrado!");
            }

            return BadRequest("Informe um parâmetro de busca: id ou nome");
        }


    }
}