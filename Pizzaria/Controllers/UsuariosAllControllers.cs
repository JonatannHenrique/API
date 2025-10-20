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

        [HttpGet]
        public IActionResult GetAll(ulong Id, string Nome, string Email, int Telefone)
        {
            var usuarios = _context.Clientes.Find(Id);
            if (usuarios == null)
                return BadRequest($"o usuario {usuarios.Nome} não foi encontrado");

            return Ok(new
            {
                Id = usuarios.Id,
                Nome = usuarios.Nome,
                Email = usuarios.Email,
                Senha = usuarios.Senha,
                Telefone = usuarios.Telefone
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuarios = _context.Clientes.Find(id);
            if (usuarios == null)
            {
                return BadRequest($"O ID: {id} não foi encontrado!");
            }
            return Ok(new
            {
                Id = usuarios.Id,
                Nome = usuarios.Nome,
                Email = usuarios.Email,
                Senha = usuarios.Senha,
                Telefone = usuarios.Telefone
            });
        }

        [HttpPost]
        public IActionResult Create(Cadastro usuario)
        {
            if (_context.Clientes.Any(c => c.Email == usuario.Email))
            {
                return BadRequest("Email Já está sendo usado. ");
            }


            _context.Clientes.Add(usuario);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Cadastro Feito"
            });
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(ulong id, [FromBody] Cadastro usuarioAtualizado)
        {
            var usuarioExistente = _context.Clientes.Find(id);

            if (usuarioExistente == null)
                return NotFound($"Usuário com ID {id} não encontrado");

            usuarioExistente.Nome = usuarioAtualizado.Nome;
            usuarioExistente.Email = usuarioAtualizado.Email;
            usuarioExistente.Telefone = usuarioAtualizado.Telefone;
            usuarioExistente.Senha = usuarioAtualizado.Senha;

            _context.Clientes.Update(usuarioExistente);
            _context.SaveChanges();

            return Ok("Usuário atualizado com sucesso!");
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var usuarios = _context.Clientes.Find(id);
            if (usuarios == null)
            {
                return NotFound("Usuario Não Encontrado!");
            }
            _context.Clientes.Remove(usuarios);
            _context.SaveChanges();
            return NoContent();
        }
    }
}



