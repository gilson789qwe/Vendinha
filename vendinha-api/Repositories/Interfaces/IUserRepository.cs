using Api.Models;

namespace Api.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<UserModel>> FindAll();
    Task<UserModel> FindAllBy(int id);
    Task<UserModel> Created(UserModel user);
    Task<UserModel> Update(UserModel user, int id);
    Task<Boolean> Delete(int id);
}