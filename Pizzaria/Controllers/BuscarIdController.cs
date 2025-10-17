using Microsoft.AspNetCore.Mvc;  //Using Tras as bibilotecas necessarias // Microsoft.ApsNetCore.Mvc é recursos para construir APIs web
using Microsoft.EntityFrameworkCore; // Microsoft.EntityFrameworkCore é para interagir com banco de dados usando Entity Framework Core que tbm tras alguns recursos nessesarios para contruir uma web Apis
using Pizzaria.Models; // Pizzaria.Models é o namespace onde estão os modelos de dados da aplicação, como Cadastro, Pizza, Pedido, etc...

namespace BuscarIdController
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("BuscarPorNome")]
        public IActionResult BuscarPorNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("O nome não pode estar vazio.");

            var usuario = _context.Clientes
                .FirstOrDefault(u => u.Nome.ToLower() == nome.ToLower());

            if (usuario == null)
                return NotFound($"Usuário '{nome}' não foi encontrado.");

            return Ok(usuario);
        }


        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(ulong id)
        {
            var busca = _context.Clientes.FirstOrDefault(b => b.Id == id);
            if (busca == null)
            {
                return BadRequest($"Erro! Usuario com o Id ({id}) não foi encontrado");
            }
            return Ok(busca);
        }
    }
}