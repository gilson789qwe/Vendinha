using Api.Controllers;

namespace Api.Repositories.Interfaces;

public interface ICustomerDebtRepository
{
    Task<List<CustomerDebtModel>> FindAll();
    Task<CustomerDebtModel> Created(CustomerDebtModel debt);
    Task<CustomerDebtModel> Update(CustomerDebtModel debt, int id);
}