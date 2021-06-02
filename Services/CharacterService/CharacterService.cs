using System.Collections.Generic;
using asp.net_webapi_learning.Models;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_webapi_learning.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> Characters = new List<Character>{new Character(), new Character{Id =1 ,Name = "sam"}};

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            Characters.Add(newCharacter);
            serviceResponse.Data = Characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = Characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = Characters.FirstOrDefault(c => c.Id == id);
            return serviceResponse;
        }
    }
}