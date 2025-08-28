using System.Text.Json.Serialization;

namespace Pizzaria.Models;
public class Cadastro
{

    [JsonIgnore]
    public ulong Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public int? Telefone { get; set; }

}