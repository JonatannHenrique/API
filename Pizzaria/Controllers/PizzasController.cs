//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Pizzaria.Models;

//namespace MinhaApi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class ControllerPizza : ControllerBase
//    {
//        private readonly AppDbContext _context;
//        public ControllerPizza(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<Pizza>> GetUsuarios()
//        {
//            return await _context.Pizzas.ToListAsync();
//        }

//        [HttpGet("{nome}")]
//        public async Task<IEnumerable<Pizza>> GetPorNome(decimal preco)
//        {
//            return await _context.Pizzas
//                .AsQueryable()
//                .Where(u => u.preco == preco)
//                .ToListFist(preco);
//        }
//    }
//}