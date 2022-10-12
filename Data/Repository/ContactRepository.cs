using AgendaAPI.DTOs;
using AgendaAPI.Entities;

namespace AgendaAPI.Data.Repository
{
    public class ContactRepository
    {
        public static List<Contact> FakeContacts = new List<Contact>()
        {
            new Contact()
            {
                CelularNumber = 3416789545,
                Name = "Nicolas",
                Description = "hermano",
                Id = 1
            },
            new Contact()
            {
                CelularNumber = 3412345678,
                Name = "Mateo",
                Description = "primo",
                Id = 2
            },
        };

        public List<Contact> GetAll()
        {
            return FakeContacts;
        }

        public bool CreateContact(ContactForCreationDTO contactDTO)
        {
            Contact contact = new Contact()
            {
                Name = contactDTO.Name,
                TelephoneNumber = contactDTO.TelephoneNumber,
                Id = contactDTO.Id,
                CelularNumber = contactDTO.CelularNumber,
                Description = contactDTO.Description,
            };
            FakeContacts.Add(contact);
            return true;
        }



    }

}
