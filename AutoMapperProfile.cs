using asp.net_webapi_learning.Dtos.Character;
using asp.net_webapi_learning.Models;
using AutoMapper;

namespace asp.net_webapi_learning
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            
        }
        
    }
}