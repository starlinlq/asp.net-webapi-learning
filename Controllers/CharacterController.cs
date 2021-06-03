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
        public async Task<ActionResult<List<AddCharacterDto>>> AddCharacter(Character newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        
    }
}