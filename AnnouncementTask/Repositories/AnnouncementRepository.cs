using AnnouncementTask.Entities;
using AnnouncementTask.Interfaces;

namespace AnnouncementTask.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly ApplicationDbContext _context;
        public AnnouncementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void AddAnnouncement(Announcement newAnnouncement)
        {
            _context.Announcements.Add(newAnnouncement);
            _context.SaveChanges();
        }

        public void DeleteAnnouncement(Announcement toDelete)
        {
            _context.Announcements.Remove(toDelete);
            _context.SaveChanges();
        }

        public void EditAnnouncement(Announcement update)
        {
            var announcement = _context.Announcements.Find(update.Id);
            announcement.Title = update.Title;
            announcement.Description = update.Description;
            _context.SaveChanges();
        }

        public Announcement GetAnnouncement(int id)
        {
            return _context.Announcements.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Announcement> GetAnnouncements()
        {
            return _context.Announcements;
        }
    }
}
