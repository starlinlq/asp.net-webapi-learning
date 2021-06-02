using asp.net_webapi_learning.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace asp.net_webapi_learning.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacter();
        Task<ServiceResponse<Character>> GetCharacterById(int id);
        Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
        
    }
}