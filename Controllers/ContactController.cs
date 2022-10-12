using AgendaAPI.Data.Repository;
using AgendaAPI.DTOs;
using AgendaAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository _contactRepository { get; set; }
        public ContactController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_contactRepository.GetAll());
        }

        [HttpGet]
        [Route("GetOne/{Id}")]
        public IActionResult GetOneById(int Id)
        {
            List<Contact> contactToReturn = _contactRepository.GetAll();
            contactToReturn.Where(x => x.Id == Id).ToList();
            if (contactToReturn.Count > 0)
                return Ok(contactToReturn);
            return NotFound("Contacto inexistente");
        }

        [HttpPost]
        public IActionResult CreateContact(ContactForCreationDTO contactDTO)
        {
            _contactRepository.CreateContact(contactDTO);
            return NoContent();

        }
    }
}
