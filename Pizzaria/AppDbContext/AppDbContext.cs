using Microsoft.EntityFrameworkCore;
namespace Pizzaria.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Cadastro> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
}