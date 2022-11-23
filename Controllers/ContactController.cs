using AgendaAPI.Data.Repository;
using AgendaAPI.Data.Repository.Interfaces;
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
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_contactRepository.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetOne(int Id)
        {
            return Ok(_contactRepository.GetAll().Where(x => x.Id == Id));
        }


        [HttpPost]
        public IActionResult CreateContact(ContactForCreationDTO createContactDto)
        {
            try
            {
                _contactRepository.Create(createContactDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", createContactDto);
        }

        [HttpPut]
        public IActionResult UpdateContact(ContactForCreationDTO dto)
        {
            try
            {
                _contactRepository.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteContactById(int id)
        {
            try
            {
                _contactRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
    }
}
