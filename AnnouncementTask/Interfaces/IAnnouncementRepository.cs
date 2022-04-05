using AnnouncementTask.Entities;

namespace AnnouncementTask.Interfaces
{
    public interface IAnnouncementRepository
    {
        IEnumerable<Announcement> GetAnnouncements();
        void AddAnnouncement(Announcement newAnnouncement);
        void EditAnnouncement(Announcement update);
        void DeleteAnnouncement(Announcement toDelete);
        Announcement GetAnnouncement(int id);
    }
}
