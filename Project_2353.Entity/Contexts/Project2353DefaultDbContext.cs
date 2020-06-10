using Microsoft.EntityFrameworkCore;
using Project_2353.Entity.Entities;

namespace Project_2353.Entity.Contexts
{
    public class Project2353DefaultDbContext:DbContext
    {
        public Project2353DefaultDbContext(DbContextOptions options):base(options)
        {
            
        }
        
        public virtual DbSet<UserEntity> User { get; set; }
        
    }
}