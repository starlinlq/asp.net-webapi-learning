using System.Collections.Generic;
using asp.net_webapi_learning.Models;
using System.Linq;
using System.Threading.Tasks;
using asp.net_webapi_learning.Dtos.Character;
using AutoMapper;
using System;

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

        public async Task<ServiceResponse<List<AddCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
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

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try{
            Character character = Characters.FirstOrDefault(c=> c.Id == updateCharacter.Id);
            character.Name = updateCharacter.Name;
            character.HitPoints = updateCharacter.HitPoints;
            character.Strenght = updateCharacter.Strenght;
            character.Defense = updateCharacter.Defense;
            character.Intelligense = updateCharacter.Intelligense;
            character.Type = updateCharacter.Type;
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }catch(Exception ex){
                serviceResponse.Success =false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
             var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{
            Character character = Characters.First(c=> c.Id == id);
            Characters.Remove(character);
            serviceResponse.Data = Characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();

            }catch(Exception ex){
                serviceResponse.Success =false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}