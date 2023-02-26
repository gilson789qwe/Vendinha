using Api.Data;
using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class DebtRepository : IDebtRepository
{
    private readonly SystemTaskDBContex _dbContex;
    
    public DebtRepository (SystemTaskDBContex systemTaskDbContex)
    {
        _dbContex = systemTaskDbContex;
    }
 
    public async Task<List<DebtModel>> FindAll()
    {
        return await _dbContex.Debts.ToListAsync();
    }
    
    public async Task<DebtModel> FindAllBy(int id)
    {
        return await _dbContex.Debts.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<DebtModel> Created(DebtModel debt)
    {
        DateTime dateTime = DateTime.UtcNow.Date;

        debt.DataCriacao = dateTime.Date;
        debt.Situacao = 0; //Não pago por padrão
        await _dbContex.Debts.AddAsync(debt);
        _dbContex.SaveChangesAsync();

        return debt;
    }
    
    public async Task<DebtModel> Update(DebtModel debt, int id)
    {
        DebtModel debtId =  await FindAllBy(id);

        if (debtId== null)
        {
            throw new Exception($"Usuário ID {id} não foi encontrado");
        }

        debtId.Situacao = debt.Situacao; //0 não paga e 1 paga
        debtId.UserId = debt.UserId;
        debtId.DataPagamento = debt.DataPagamento;
        debtId.Valor = debt.Valor;
        debtId.DataCriacao = debt.DataCriacao;

        _dbContex.Debts.Update(debtId);
        await _dbContex.SaveChangesAsync();

        return debtId;
    }
    
    public async Task<bool> Delete(int id)
    {
        DebtModel debtId =  await FindAllBy(id);

        if (debtId == null)
        {
            throw new Exception($"Divida ID {id} não foi encontrado");
        }

        _dbContex.Debts.Remove(debtId);
        await _dbContex.SaveChangesAsync();

        return true;
    }
    
}