using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Models;

namespace MinhaApi.Controllers
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

        [HttpGet("{nome}")]
        public async Task<IEnumerable<Cadastro>> GetPorNome(string nome)
        {
            return await _context.Clientes
                .AsQueryable()
                .Where(u => u.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}