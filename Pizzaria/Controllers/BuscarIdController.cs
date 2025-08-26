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
        [HttpGet("BuscarPorNome")]
        public IActionResult BuscaPorNome(string nome)
        {
            var usuario = _context.Clientes.FirstOrDefault(u => u.Nome == nome);

            if (usuario == null)
            {
                return NotFound(new { message = "User not found." });
            }
            return Ok(usuario);
        }
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int id)
        {
            var Usuario = _context.Clientes.FirstOrDefault(u => u.Id == (ulong)id);
            if(Usuario == null )
            {
                return NotFound(new { message = "User Not found. " });
            }
            return Ok(Usuario);
        }

       

    }
}