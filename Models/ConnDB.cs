using Microsoft.EntityFrameworkCore;
namespace CrudUser.Models
{
    public class ConnDB : DbContext
    {
        
        public ConnDB(DbContextOptions<ConnDB> options) :base (options)
        {

        }
        public DbSet<User> UserItem {get; set;}
        
    }
}