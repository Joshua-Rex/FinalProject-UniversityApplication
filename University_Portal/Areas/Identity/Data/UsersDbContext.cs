using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University_Portal.Areas.Identity.Data;
using University_Portal.Models;

namespace University_Portal.Data;

public class UsersDbContext : IdentityDbContext<User>
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<University_Portal.Models.Courses> Courses { get; set; } = default!;

    public DbSet<University_Portal.Models.Events> Events { get; set; } = default!;

    public DbSet<University_Portal.Models.Modules> Modules { get; set; } = default!;

    public DbSet<University_Portal.Models.Universities> Universities { get; set; } = default!;
}
