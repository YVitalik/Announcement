using AnnouncementTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementTask
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Announcement> Announcements { get; set; }
    }
}
