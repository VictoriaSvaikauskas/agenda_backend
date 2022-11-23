using AgendaAPI.DTOs;
using AgendaAPI.Entities;

namespace AgendaAPI.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
        public User? GetById(int userId);
        public List<User> GetAll();
        public void Create(UserForCreationDTO dto);
        public void Update(UserForCreationDTO dto);
        public void Delete(int id);
    }
}
