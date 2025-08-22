using Microsoft.AspNetCore.Mvc;  //Using Tras as bibilotecas necessarias // Microsoft.ApsNetCore.Mvc é recursos para construir APIs web
using Microsoft.EntityFrameworkCore; // Microsoft.EntityFrameworkCore é para interagir com banco de dados usando Entity Framework Core que tbm tras alguns recursos nessesarios para contruir uma web Apis
using Pizzaria.Models; // Pizzaria.Models é o namespace onde estão os modelos de dados da aplicação, como Cadastro, Pizza, Pedido, etc...

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