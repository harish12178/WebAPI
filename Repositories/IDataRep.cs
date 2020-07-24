using MyProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MyProject.Repositories
{
    public interface IDataRep
    {
            Task<List<UserModel>> GetUser();
            Task<UserModel> GetUser(int id);
            Task<UserModel> CreateUser(UserModel user);
            void DeleteUser(int id);
            Task<UserModel> UpdateUser(UserModel user);
    }
}