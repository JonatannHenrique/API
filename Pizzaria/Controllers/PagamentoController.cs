using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;

namespace Pizzaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PagamentoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult CriarPagamento(Pagamento pagamento)
        {
            pagamento.Data = DateTime.Now;

            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPagamentoPorId), new { id = pagamento.Id }, pagamento);
        }


        [HttpGet("{id}")]
        public IActionResult GetPagamentoPorId(int id)
        {
            var pagamento = _context.Pagamentos.FirstOrDefault(p => p.Id == id);
            if (pagamento == null)
                return NotFound();

            return Ok(pagamento);
        }


        [HttpGet]
        public IActionResult GetTodosPagamentos()
        {
            return Ok(_context.Pagamentos.ToList());
        }
        [HttpGet("PedidoMaisRecente")]
        public IActionResult GetPedidoMaisRecente()
        {
            var pedido = _context.Pedidos
                .OrderByDescending(p => p.Data) 
                .FirstOrDefault();

            if (pedido == null)
                return NotFound();

            return Ok(new { id = pedido.Id, valor = pedido.ValorTotal });
        }
    }
}
