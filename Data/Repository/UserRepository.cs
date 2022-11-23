using AgendaAPI.Data.Repository.Interfaces;
using AgendaAPI.DTOs;
using AgendaAPI.Entities;
using AutoMapper;

namespace AgendaAPI.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        private AgendaApiContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AgendaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Create(UserForCreationDTO dto)
        {
            _context.Users.Add(_mapper.Map<User>(dto));
        }

        public void Update(UserForCreationDTO dto)
        {
            _context.Users.Update(_mapper.Map<User>(dto));
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
        }
    }
}
