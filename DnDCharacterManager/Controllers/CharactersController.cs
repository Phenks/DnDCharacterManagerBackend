using AuthService;
using DnDCharacterManager.Manager;
using DnDCharacterManager.Models.DTO;
using DnDCharacterManager.Models.Wrapper;
using DnDCharacterManager.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Net;
using System.Security.Claims;

namespace DnDCharacterManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ILogger<CharactersController> _logger;

        public CharactersController(ILogger<CharactersController> logger)
        {
            _logger = logger;
        }


       

        [HttpPost(Name = "ImportCharacterFromDnDBeyond")]
        [Authorize]
        public ActionResult<CharacterDTO> Post([FromBody] CharId characterId)
        {
            var client = RestSharpHelper.GetClient(Constants.Urls.DND_BEYOND_CHARACTER_SERVICE);
            var request = new RestRequest(characterId.CharacterId);
            var response = client.Get<BeyondCharacterWrapper>(request);
            
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest();
            };

            BeyondCharacterWrapper beyondChar = response.Data;


            var character = CharacterManager.CreateCharacter((Character)beyondChar, AuthHelper.GetUser(HttpContext));
            
            return Ok(new CharacterDTO(character));

        }
        [HttpGet(Name = "GetAllCharacters")]
        [Authorize]
        public ActionResult<List<CharacterDetailDTO>> Get()
        {
            var user = AuthHelper.GetUser(HttpContext);

            using (DnDContext dndContext = new DnDContext())
            {
                return dndContext.Characters.Where(c => c.PlayerId == user.Id).Include(c => c.Currency).Include(c => c.Classes).Include(c => c.Items).Select(c => new CharacterDetailDTO(c)).ToList();
            }
        }

        public class CharId
        {
            public string CharacterId { get; set; }
        }
    }
}