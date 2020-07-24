using Microsoft.EntityFrameworkCore;
namespace MyProject.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> UserData { get; set; }
    }
}