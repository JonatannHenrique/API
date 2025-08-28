using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;

namespace Pizzaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context) { _context = context; }

        [HttpGet("pedidos")]
        public IActionResult GetTodosPedidos() //  Retorna todos os pedidos em Json 
        {
            var pedidos = _context.Pedidos.ToList();
            return Ok(pedidos);
        }

        [HttpGet("PedidoPorId")]
        public IActionResult GetPedidosPorId(int Id) //  retorna quem fez o pedido e oq pediu 
        {
            var pedidos = _context.Pedidos
                .Where(p => p.Id == Id)
                .ToList();
            return Ok(pedidos);
        }

        [HttpGet("PedidoPorNome")]
        public IActionResult GetBuscarPedidoPorNome(int PizzaId)
        {
            var pedidos = _context.Pedidos
                .Where(p => p.PizzaId == PizzaId)
                .ToList();
            return Ok(pedidos);
        }
    }
}