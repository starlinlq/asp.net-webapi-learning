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