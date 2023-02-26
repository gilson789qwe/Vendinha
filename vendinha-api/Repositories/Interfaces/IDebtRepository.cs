using Api.Models;

namespace Api.Repositories.Interfaces;

public interface IDebtRepository
{
    Task<List<DebtModel>> FindAll();
    Task<DebtModel> FindAllBy(int id);
    Task<DebtModel> Created(DebtModel debt);
    Task<DebtModel> Update(DebtModel debt, int id);
    Task<Boolean> Delete(int id);
}