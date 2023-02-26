using Api.Data;
using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SystemTaskDBContex _dbContex;
    public UserRepository(SystemTaskDBContex systemTaskDbContex)
    {
        _dbContex = systemTaskDbContex;
    }
    public async Task<List<UserModel>> FindAll()
    {
        return await _dbContex.Users.ToListAsync();
    }

    public async Task<UserModel> FindAllBy(int id)
    {
        return await _dbContex.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserModel> Created(UserModel user)
    {
        await _dbContex.Users.AddAsync(user);
        _dbContex.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> Update(UserModel user, int id)
    {
        UserModel userId =  await FindAllBy(id);

        if (userId == null)
        {
            throw new Exception($"Usuário ID {id} não foi encontrado");
        }

        userId.Nome = user.Nome;
        userId.Email = user.Email;
        userId.DataNascimento = user.DataNascimento;
        userId.CPF = user.CPF;

        _dbContex.Users.Update(userId);
       await _dbContex.SaveChangesAsync();

        return userId;
    }

    public async Task<bool> Delete(int id)
    {
        UserModel userId =  await FindAllBy(id);

        if (userId == null)
        {
            throw new Exception($"Usuário ID {id} não foi encontrado");
        }

        _dbContex.Users.Remove(userId);
        await _dbContex.SaveChangesAsync();

        return true;
    }
}