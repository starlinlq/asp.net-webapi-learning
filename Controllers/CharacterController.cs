using Microsoft.AspNetCore.Mvc;
using asp.net_webapi_learning.Models;
using System.Collections.Generic;
using System.Linq;
using asp.net_webapi_learning.Services.CharacterService;
using System.Threading.Tasks;

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

        
        public async Task<ActionResult<List<Character>>> Get()
        {
            return Ok(await _characterService.GetAllCharacter());
            
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Character>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
            
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        
    }
}