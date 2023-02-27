using Api.Controllers;
using Api.Data;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class CustomerDebtRepository: ICustomerDebtRepository
{
    private readonly SystemTaskDBContex _dbContex;
    
    public CustomerDebtRepository (SystemTaskDBContex systemTaskDbContex)
    {
        _dbContex = systemTaskDbContex;
    }
    
    public async Task<List<CustomerDebtModel>> FindAll()
    {
        List<CustomerDebtModel> customer = await _dbContex.CustomerDebts.ToListAsync();
        
        return customer;

    }
    
    public async Task<CustomerDebtModel> Created(CustomerDebtModel customer)
    {
        customer.Situacao = 0; //Não pago por padrão
        await _dbContex.CustomerDebts.AddAsync(customer);
        _dbContex.SaveChangesAsync();

        return customer;
    }

    public Task<CustomerDebtModel> Update(CustomerDebtModel debt, int id)
    {
        throw new NotImplementedException();
    }
}