using AutoMapper;
using DTO;
using EntityLayer.Concrete;

namespace Capstone.Mapping.AutomapperProfile
{
    public class GameProfile: Profile
    {
        public GameProfile() 
        {
            CreateMap<Game, GameDto>().ReverseMap();
        }
    }
}
