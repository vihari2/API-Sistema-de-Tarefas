using Microsoft.EntityFrameworkCore;
using WorkSystem.Data;
using WorkSystem.Models;
using WorkSystem.Repository.Interfaces;

namespace WorkSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WorkSystemDBConec _dbContext;

        public UserRepository(WorkSystemDBConec workSystemDBConec) 
        {
            _dbContext = workSystemDBConec;
        }

        public async Task<UserModel> FindById(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<UserModel> Add(UserModel user)
        {
           await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
          UserModel FindUserById = await FindById(id);
            if(FindUserById == null)
            {
                throw new Exception($"User by Id: {id} not found on database.");
            }
            FindUserById.Name = user.Name;
            FindUserById.Email = user.Email;

            _dbContext.User.Update(FindUserById);
            await _dbContext.SaveChangesAsync();

            return FindUserById;

        }

        public async Task<bool> Delete(int id)
        {
            UserModel FindUserById = await FindById(id);
            if (FindUserById == null)
            {
                throw new Exception($"User by Id: {id} not found on database.");
            }
            _dbContext.User.Remove(FindUserById);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public Task<UserModel> Update(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }





}
