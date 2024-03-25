using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EduPost.Models;

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
    }
}
