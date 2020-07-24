using System;
using MyProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories;
namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController:ControllerBase
    {
       private readonly IDataRep repo;
       public UserController(IDataRep repository){
           this.repo=repository;
       }
       [HttpGet]
       public async Task<ActionResult<List<UserModel>>> Get(){
           return Ok(await repo.GetUser());
       }

       [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var user = await repo.GetUser(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(UserModel user)
        {
            var created_user=await repo.CreateUser(user);
            return CreatedAtAction(nameof(Get),new {id = created_user.id}, created_user);
        }
            [HttpDelete("{id}")]
    public async Task<ActionResult<UserModel>> Delete(int id)
    {
        
            var user_to_deleted = await repo.GetUser(id);

            if (user_to_deleted == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            repo.DeleteUser(id);
            return Ok(user_to_deleted);
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> Update(int id, UserModel user)
    {
            var user_to_update = await repo.GetUser(id);

            if (user_to_update == null)
                return NotFound($"User with Id = {id} not found");

            return Ok(await repo.UpdateUser(user));   
    }        
 }
}