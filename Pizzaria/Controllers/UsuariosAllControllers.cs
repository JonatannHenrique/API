using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using Pizzaria.Models;

namespace Pizzaria.Controllers
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

        //[HttpGet]
        //public IActionResult GetAll() { }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id) {  }

        //[HttpPost]
        //public IActionResult Create(Usuario usuario) { }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Usuario usuario) {  }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var usuario = _context.Clientes.Find(id);
            if (usuario == null)
            {
                return NotFound("Usuario Não Encontrado!");
            }
            _context.Clientes.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }
    }
}



