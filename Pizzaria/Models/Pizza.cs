namespace Pizzaria.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public decimal ValorTotal { get; set; }
        public int Id { get; internal set; }
    }
}

