using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University_Portal.Models;

namespace University_Portal.Data
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext (DbContextOptions<PortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<University_Portal.Models.Students> Students { get; set; } = default!;

        public DbSet<University_Portal.Models.Tutors> Tutors { get; set; } = default!;

        public DbSet<University_Portal.Models.Universities> Universities { get; set; } = default!;

        public DbSet<University_Portal.Models.Courses> Courses { get; set; } = default!;

        public DbSet<University_Portal.Models.Modules> Modules { get; set; } = default!;

        public DbSet<University_Portal.Models.StudentEvents> StudentEvents { get; set; } = default!;

        public DbSet<University_Portal.Models.TutorEvents> TutorEvents { get; set; } = default!;
    }
}
