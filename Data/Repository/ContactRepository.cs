using AgendaAPI.Data.Repository.Interfaces;
using AgendaAPI.DTOs;
using AgendaAPI.Entities;
using AutoMapper;

namespace AgendaAPI.Data.Repository
{
    public class ContactRepository:IContactRepository
    {
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(AgendaApiContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList(); ;
        }

        public void Create(ContactForCreationDTO dto)
        {
            _context.Contacts.Add(_mapper.Map<Contact>(dto));
        }

        public void Update(ContactForCreationDTO dto)
        {
            _context.Contacts.Update(_mapper.Map<Contact>(dto));
        }
        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
        }

    }

}
