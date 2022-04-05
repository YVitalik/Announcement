using AnnouncementTask.DTOs;
using AnnouncementTask.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementTask.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_announcementService.GetAnnouncements());
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            try
            {
                _announcementService.DeleteAnnouncement(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateAnnouncement(CreateAnnouncementDto announcement)
        {
             _announcementService.AddAnnouncement(announcement);
             return Ok();
        }

        [HttpPost("update")]
        public IActionResult UpdateAnnouncement(UpdateAnnouncementDto announcement)
        {
            try
            {
                _announcementService.EditAnnouncement(announcement);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetAnnouncementById(int id)
        {
            try
            {
                return Ok(_announcementService.GetByIdWithReleated(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
