using Microsoft.EntityFrameworkCore;
namespace Pizzaria.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<Pizza> pizzas { get; set; }
    public DbSet<Cadastro> Clientes { get; set; }
    public DbSet<Pedido> pizzapedido { get; set; }
    public object Pedido { get; internal set; }
    public object Pizza { get; internal set; }
}
