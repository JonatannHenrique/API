using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;

namespace Pizzaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPizza : ControllerBase
    {
        private readonly AppDbContext _context;

        public ControllerPizza(AppDbContext context) { _context = context; }

        [HttpGet("{id}")]
        public IActionResult GetPedidoPorId(int id)
        {
            var pizza = _context.Pedidos.FirstOrDefault(p => p.Id == id);
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound($"Pedido com ID {id} não foi encontrado.");
            return Ok(pedido);
        }       
        [HttpPost("Pedidos")]
        public IActionResult CriarPedido([FromBody] Pedido pedido)
        {
            if (pedido == null || pedido.PizzaId == 0 || pedido.PizzaId >= 11)
                return BadRequest("Pedido inválido. Verifique Se A Pizza Selecionada Esta Disponivel!");
            if (pedido.Quantidade == 0)
                return BadRequest("Quantidade inválida. A quantidade Deve ser maior que zero.");

            var pizzas = _context.Pizzas.FirstOrDefault(p => p.Id == pedido.PizzaId);
            if (pizzas == null)
                return BadRequest("Pizza não encontrada.");
                        
            var ValorTotal = pizzas.preco * pedido.Quantidade;
            var novoPedido = new Pedido
            {                
                PizzaId = pedido.PizzaId,
                Quantidade = pedido.Quantidade,
                Data = pedido.Data = DateTime.Now,
                Endereco = pedido.Endereco,
                ValorTotal = pedido.Quantidade * pizzas.preco
            };
                      
            _context.Pedidos.Add(novoPedido);
            _context.SaveChanges();

            return Ok(new
            {             
                message = "pedido Feito, Aguarde",
            });
        }
    }
}