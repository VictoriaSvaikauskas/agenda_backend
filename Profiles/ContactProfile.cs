using AgendaAPI.DTOs;
using AgendaAPI.Entities;
using AutoMapper;

namespace AgendaAPI.Profiles
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactForCreationDTO>();
        }

    }
}
