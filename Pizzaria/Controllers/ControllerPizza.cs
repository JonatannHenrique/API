using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;




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
            var pizza = _context.pizzapedido.FirstOrDefault(p => p.Id == id);
            var pedido = _context.pizzapedido.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound($"Pedido com ID {id} não foi encontrado.");
            return Ok(pedido);
        }

        [HttpPost("criar")]
        public IActionResult CriarPedido([FromBody] Pedido pedido)
        {
            if (pedido == null || pedido.PizzaId == 0 || pedido.PizzaId >= 11)
                return BadRequest("Pedido inválido. Verifique Se A Pizza Selecionada Esta Disponivel!");

            
            var pizza = _context.pizzas.FirstOrDefault(p => p.Id == pedido.PizzaId);
            if (pizza == null)
                return BadRequest("Pizza não encontrada.");
                

            var novoPedido = new Pedido
            {
                PizzaId = pedido.PizzaId,
                Quantidade = pedido.Quantidade,
                Endereco = pedido.Endereco
            };

            _context.pizzapedido.Add(novoPedido);
            _context.SaveChanges();

            return Ok(new
            {
                message = "pedido Feito, Aguarde",
            });
        }
    }
}