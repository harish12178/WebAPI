
using System.ComponentModel.DataAnnotations;
namespace MyProject.Models
{
    public class UserModel
    {
        [Key]
        public int id {get;set;}
        public string username {get;set;}
        public int age{get;set;}
        public string email{get;set;}
    }
}