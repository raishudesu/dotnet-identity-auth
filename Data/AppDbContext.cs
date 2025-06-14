using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dotnet_authentication.Models;

namespace dotnet_authentication.Data
{
    // INITIATES THE DATABASE CONTEXT FOR THE APPLICATION
    // INHERITS FROM IdentityDbContext TO HANDLE USER AUTHENTICATION AND ROLES
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        // DbSet for UserTasks to represent the UserTask table in the database
        public DbSet<UserTask> UserTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define One-to-Many Relationship
            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ut => ut.UserId);
        }
    }
}
