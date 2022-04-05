using AnnouncementTask.DTOs;
using AnnouncementTask.Entities;

namespace AnnouncementTask.Interfaces
{
    public interface IAnnouncementService
    {
        IEnumerable<Announcement> GetAnnouncements();
        void AddAnnouncement(CreateAnnouncementDto newAnnouncement);
        void EditAnnouncement(UpdateAnnouncementDto update);
        void DeleteAnnouncement(int id);
        IEnumerable<ReadAnnouncementDto> GetByIdWithReleated(int id);
    }
}
