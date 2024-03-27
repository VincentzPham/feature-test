using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EduPost.Models;
using System.Data;
using System.Reflection.Emit;


namespace EduPost.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EduPost.Models.User>? User { get; set; }
        public DbSet<EduPost.Models.Article>? Article { get; set; }
        public DbSet<EduPost.Models.Status>? Status { get; set; }
        public DbSet<EduPost.Models.Comment>? Comment { get; set; }
        public DbSet<EduPost.Models.Faculty> Faculty { get; set; } = default!;
        public DbSet<EduPost.Models.Role> Role { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            var adminusers = new[]
            {
                new User 
                { 
                    Id = 1, 
                    UserName = "TestEmail@email.com",
                    Email = "TestEmail@email.com",
                    Faculty = "Admin",
                    Role = "Admin",
                    NormalizedUserName = "TESTEMAIL@EMAIL.COM",
                    NormalizedEmail = "TESTEMAIL@EMAIL.COM",
                    EmailConfirmed = true,
                    //Pasword:Admin@01
                    PasswordHash = "AQAAAAIAAYagAAAAEBdGZDqY/P61BXsLDI0xzUn5ZqaiwOMGgzYjGpoJKv8eMggcDxUGL2GZcoVXetrUpA==",
                    SecurityStamp = "P326W733E2RXH66PPK4ZYOQRQREJTMUD",
                    ConcurrencyStamp = "61521b0c-13fb-44a0-b67c-f753cf71bba5",
                    LockoutEnabled = true,
                }
            };
            builder.Entity<User>().HasData(adminusers);

            var adminrole = new[]
            { new Role { Id = 1,Name = "Admin", NormalizedName = "ADMIN"},
              new Role { Id = 2,Name = "User", NormalizedName = "USER"} };
            builder.Entity<Role>().HasData(adminrole);

            var userRolePairs = new[]
            {
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
            };
            builder.Entity<IdentityUserRole<int>>().HasData(userRolePairs);
        }
    }
}
