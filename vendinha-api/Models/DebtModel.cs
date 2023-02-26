using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class DebtModel
{
    public int Id { get; set; }
    
    public int Valor { get; set; }
    
    public int Situacao { get; set; }
    
    public DateTime DataCriacao { get; set; }
    
    public DateTime DataPagamento { get; set; }

    public UserModel User { get; set; }
}