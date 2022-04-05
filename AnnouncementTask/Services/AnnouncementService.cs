using AnnouncementTask.DTOs;
using AnnouncementTask.Entities;
using AnnouncementTask.Interfaces;

namespace AnnouncementTask.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _repository;
        public AnnouncementService(IAnnouncementRepository repository)
        {
            _repository = repository;
        }
        
        public void AddAnnouncement(CreateAnnouncementDto newAnnouncement)
        {
            var announcement = new Announcement
            {
                Title = newAnnouncement.Title,
                Description = newAnnouncement.Description,
                DateAdded = DateTime.Now
            };

            _repository.AddAnnouncement(announcement);
        }

        public void DeleteAnnouncement(int id)
        {
            var announcementToDelete = _repository.GetAnnouncement(id);
            
            if (announcementToDelete is null)
            {
                throw new ArgumentException("Announcement with such id doesnt exist");
            }

            _repository.DeleteAnnouncement(announcementToDelete);
        }

        public void EditAnnouncement(UpdateAnnouncementDto update)
        {
            var check = _repository.GetAnnouncement(update.Id);

            if (check is null)
            {
                throw new ArgumentException("Announcement that you want to update doesnt exist");
            }

            var updateAnnouncement = new Announcement
            {
                Id = update.Id,
                Title = update.Title,
                Description = update.Description,
                DateAdded = check.DateAdded
            };

            if ((updateAnnouncement.Title == null) || (updateAnnouncement.Title == ""))
            {
                updateAnnouncement.Title = check.Title;
                _repository.EditAnnouncement(updateAnnouncement);
            }

            if ((updateAnnouncement.Description == null) || (updateAnnouncement.Description == ""))
            {
                updateAnnouncement.Description = check.Description;
                _repository.EditAnnouncement(updateAnnouncement);
            }

            if ( ((updateAnnouncement.Description == null) || (updateAnnouncement.Description == "")) && ((updateAnnouncement.Title == null) || (updateAnnouncement.Title == "")))
            {
                updateAnnouncement.Title = check.Title;
                updateAnnouncement.Description = check.Description;
                _repository.EditAnnouncement(updateAnnouncement);
            }

            _repository.EditAnnouncement(updateAnnouncement);
        }

        public IEnumerable<Announcement> GetAnnouncements()
        {
            var result = _repository.GetAnnouncements();

            if (result.Count() == 0)
            {
                throw new ArgumentException("The list of announcements is empty right now, try to add new announcement");
            }

            return result;
        }

        public IEnumerable<ReadAnnouncementDto> GetByIdWithReleated(int id)
        {
            var check = _repository.GetAnnouncement(id);
            var announcements = _repository.GetAnnouncements();

            if (check is null)
            {
                throw new ArgumentException("Announcement doesnt exist exception");
            }

            var announcement = new ReadAnnouncementDto
            {
                Title = check.Title,
                Description = check.Description,
                DateAdded = check.DateAdded
            };

            var result = new List<ReadAnnouncementDto>();
            result.Add(announcement);

            foreach (var item in announcements)
            {
                if (result.Count() < 4)
                {
                    if (announcement.Title.ToLower().Contains(item.Title.ToLower()) && announcement.Description.ToLower().Contains(item.Description.ToLower()))
                    {
                        var toAdd = new ReadAnnouncementDto
                        {
                            DateAdded = item.DateAdded,
                            Description = item.Description,
                            Title = item.Title
                        };

                        if (check.Id != item.Id)
                        {
                            result.Add(toAdd);
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
