using AgendaAPI.DTOs;
using AgendaAPI.Entities;
using AutoMapper;

namespace AgendaAPI.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserForCreationDTO>();
        }
    }
}
