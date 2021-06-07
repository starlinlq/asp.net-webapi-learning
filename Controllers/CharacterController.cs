using Microsoft.AspNetCore.Mvc;
using asp.net_webapi_learning.Models;
using System.Collections.Generic;
using System.Linq;
using asp.net_webapi_learning.Services.CharacterService;
using System.Threading.Tasks;
using asp.net_webapi_learning.Dtos.Character;

namespace asp.net_webapi_learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;
        public  CharacterController(ICharacterService charaterService)
        {
            _characterService = charaterService;
            
        }
        [HttpGet("GetAll")] //swagger requires this

        
        public async Task<ActionResult<List<GetCharacterDto>>> Get()
        {
            return Ok(await _characterService.GetAllCharacter());
            
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<GetCharacterDto>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
            
        }
        [HttpPost]
        public async Task<ActionResult<List<AddCharacterDto>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updateCharacter){
            var response = await _characterService.UpdateCharacter(updateCharacter);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id){
             var response = await _characterService.DeleteCharacter(id);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }

        
    }
}