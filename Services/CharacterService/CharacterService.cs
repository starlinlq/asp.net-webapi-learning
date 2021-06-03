using System.Collections.Generic;
using asp.net_webapi_learning.Models;
using System.Linq;
using System.Threading.Tasks;
using asp.net_webapi_learning.Dtos.Character;
using AutoMapper;

namespace asp.net_webapi_learning.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private static List<Character> Characters = new List<Character>{new Character(), new Character{Id =1 ,Name = "sam"}};
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
            
        }

        public async Task<ServiceResponse<List<AddCharacterDto>>> AddCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<AddCharacterDto>>();
            Characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponse.Data = Characters.Select(c=> _mapper.Map<AddCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = Characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(Characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

    }
}