using asp.net_webapi_learning.Dtos.Character;
using asp.net_webapi_learning.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace asp.net_webapi_learning.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<AddCharacterDto>>> AddCharacter(Character newCharacter);
        
    }
}