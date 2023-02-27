using System.Data;
using System.Text.Json;
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
        List<UserModel> users = await _dbContex.Users.ToListAsync();
        
        return users;

    }

    public async Task<UserModel> FindAllBy(int id)
    {
        return await _dbContex.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserModel> Created(UserModel user)
    {
        if (user.CPF.Length != 11)
        {
            throw new Exception($"O valor de CPF tem q ter 11 digidos");
        }

        string year = user.DataNascimento.Year.ToString();
        string yearNow = DateTime.Now.Year.ToString();
        string mouth = user.DataNascimento.Month.ToString();
        string mouthNow = DateTime.Now.Year.ToString();
        int idade = Convert.ToInt32(mouthNow) - Convert.ToInt32(mouth);

        if (idade >= 0)user.Idade = (Convert.ToInt32(yearNow) - Convert.ToInt32(year))-1;
        else
        {
            user.Idade = Convert.ToInt32(yearNow) - Convert.ToInt32(year);
        }
        
        List<UserModel> usersId  = await _dbContex.Users.ToListAsync();

        Boolean cpf = usersId.Any(u => u.CPF == user.CPF);
        if (cpf)
        {
            throw new Exception($"CPF já está cadastrado");
        }
        
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