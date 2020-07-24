using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Models;

namespace MyProject.Repositories
{
    public class UserDataRep:IDataRep
    {
        private readonly UserContext mycontext;

        public UserDataRep(UserContext context){
            this.mycontext=context;
        }
        public async Task<List<UserModel>> GetUser(){
            return await mycontext.UserData.ToListAsync();
        }
        public async Task<UserModel> GetUser(int id){
            return await mycontext.UserData.FirstOrDefaultAsync(user=>user.id==id);
        }
        public async Task<UserModel> CreateUser(UserModel user){
            var new_user=await mycontext.UserData.AddAsync(user);
            await mycontext.SaveChangesAsync();
            return new_user.Entity;
        }
        public async void DeleteUser(int id)
        {
            var result = await mycontext.UserData.FirstOrDefaultAsync(user => user.id == id);
            if (result != null)
            {
                mycontext.UserData.Remove(result);
                await mycontext.SaveChangesAsync();
            }
        }
        public async Task<UserModel> UpdateUser(UserModel user)
        {
            var result = await mycontext.UserData.FirstOrDefaultAsync(e => e.id == user.id);
            if (result != null)
            {
                result.username = user.username;
                result.age = user.age;
                result.email = user.email;
                await mycontext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        
    }
}