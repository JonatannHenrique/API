namespace Pizzaria.Models;

public class Pagamento
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public string Metodo { get; set; }
    public DateTime Data { get; set; }
}