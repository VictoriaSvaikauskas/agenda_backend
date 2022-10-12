using AgendaAPI.DTOs;
using AgendaAPI.Entities;

namespace AgendaAPI.Data.Repository
{
    public class UserRepository
    {
        List<User> FakeUsers = new List<User>()
        {
            new User()
            {
                Email = "hola@gmail.com",
                Name = "Victoria",
                Password = "passwordsegura",
                Id = 1
            },
            new User()
            {
                Email = "hola1@gmail.com",
                Name = "Maria",
                Password = "passwordsegura1",
                Id = 2,
            },
        };

        public List<User> GetAllUsers()
        {
            return FakeUsers;
        }

        public bool CreateUser(UserForCreationDTO userDTO)
        {
            User user = new User()
            {
                Name = userDTO.Name,
                Password = userDTO.Password,
                Id = userDTO.Id,
                Email = userDTO.Email,
            };
            FakeUsers.Add(user);
            return true;
        }

        public User? Validate(string user, string password)
        {
            return FakeUsers.SingleOrDefault(x => x.UserName == user && x.Password == password);
        }
    }
}
