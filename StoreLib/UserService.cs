using StoreDB.Models;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreLib
{
    public class UserService:IUserService
    {
        private readonly IUserRepo repo;
        public UserService(IUserRepo repo)
        {
            this.repo = repo;
        }
        public void AddUser(User user)
        {
            repo.AddUser(user);
        }
        public void UpdateUser(User user)
        {
            repo.UpdateUser(user);
        }
        public User GetUserById(int userId)
        {
            return repo.GetUserById(userId);
        }
        public User GetUserByUsername(string username)
        {
            return repo.GetUserByUsername(username);
        }
        public List<User> GetAllUsers()
        {
            List<User> results = repo.GetAllUsers();
            return results;
        }
        public void DeleteUser(User user)
        {
            repo.DeleteUser(user);
        }
    }
}
