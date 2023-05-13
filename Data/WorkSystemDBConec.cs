using Microsoft.EntityFrameworkCore;
using WorkSystem.Data.Map;
using WorkSystem.Models;

namespace WorkSystem.Data
{
    public class WorkSystemDBConec : DbContext 
    {
        public WorkSystemDBConec(DbContextOptions<WorkSystemDBConec> options)
           : base(options)
        { 
        }
       public DbSet<UserModel> User { get; set; }
       public DbSet<TasksModel> Tasks { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
