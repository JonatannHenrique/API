using System.Text.Json.Serialization;

public class Pedido
{
    public int Id { get; private set; }
    public int PizzaId { get; set; }
    public string? Endereco { get; set; }
    [JsonIgnore]
    public DateTime Data { get; set; }
    public int Quantidade { get; set; }
    [JsonIgnore]
    public decimal ValorTotal { get; set; }
}
