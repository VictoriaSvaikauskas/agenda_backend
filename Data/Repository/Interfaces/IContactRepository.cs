using AgendaAPI.DTOs;
using AgendaAPI.Entities;

namespace AgendaAPI.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAll();
        public void Create(ContactForCreationDTO dto);
        public void Update(ContactForCreationDTO dto);
        public void Delete(int id);
    }
}
