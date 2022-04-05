using System.ComponentModel.DataAnnotations;

namespace AnnouncementTask.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
