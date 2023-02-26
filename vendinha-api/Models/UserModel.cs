using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("User")]
public class UserModel
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string CPF { get; set;  }
    
    public DateTime DataNascimento { get; set; }
    
    public string Email { get; set; }
    
}