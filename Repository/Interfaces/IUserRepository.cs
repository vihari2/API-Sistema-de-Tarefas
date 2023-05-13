using WorkSystem.Models;

namespace WorkSystem.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> SearchAllUsers();
        Task<UserModel> FindById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
        Task<UserModel> Update(UserModel userModel);
    }
}
