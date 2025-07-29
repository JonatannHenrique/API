using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pizzaria.Models;
public class Login 
{
    public string? Email { get; set; }
    public string? Senha { get; set; }

}