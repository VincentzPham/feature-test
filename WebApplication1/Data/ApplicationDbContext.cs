using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //rename the table user and role, did not work properly for some reason ?
            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<Role>().ToTable("Role");

            //drop unnecessary column
            //modelBuilder.Entity<User>().Ignore(r=> r.AccessFailedCount);

            //remove the user role that create the many-many relationship between user and role
            //modelBuilder.Ignore<IdentityUserRole<int>>();
        }
        public DbSet<User>? User { get; set; }
        public DbSet<Role>? Role { get; set; }
    }
}