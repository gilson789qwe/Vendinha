namespace Api.Controllers;

public class CustomerDebtModel
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public int ValorTotal { get; set; }
    
    public int Situacao { get; set; }
    
    public int UserId { get; set; }
    
}