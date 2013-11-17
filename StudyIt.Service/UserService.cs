using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface IUserService
    {
        List<UserProfile> GetAllUsers();
        UserProfile GetUser(int userId);
    }
    public class UserService : IUserService
    {
        private IUserRepository userRepo;

        public UserService()
        {
            this.userRepo = new UserRepository(new StudyItContext());
        }
        public UserService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        public List<UserProfile> GetAllUsers()
        {
            return userRepo.GetAll().ToList();
        }

        /// <summary>
        /// Get user by given id
        /// </summary>
        /// <param name="userId">The id of a user</param>
        /// <returns></returns>
        public UserProfile GetUser(int userId)
        {
            return userRepo.Get(userId);
        }
    }
}
