using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Models.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
          protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            foreach (var fkey in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                fkey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Role> Roles { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set;}
    }
}
