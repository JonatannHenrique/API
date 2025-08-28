using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly AppDbContext _context;
    public PizzasController(AppDbContext context) { _context = context; }

    [HttpGet("ListarPizzas")]
    public IActionResult GetTodasPizzas()
    {
        var pizzas = _context.Pizzas.ToList();
        return Ok(pizzas);
    }


}
