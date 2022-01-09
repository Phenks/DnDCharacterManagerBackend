using AuthService;
using DnDCharacterManager.Manager;
using DnDCharacterManager.Models.DTO;
using DnDCharacterManager.Models.Wrapper;
using DnDCharacterManager.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

namespace DnDCharacterManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly ILogger<CharactersController> _logger;

        public SessionsController(ILogger<CharactersController> logger)
        {
            _logger = logger;
        }




        [HttpPost(Name = "CreateSession")]
        [Authorize]
        public ActionResult<SessionDTO> Post([FromBody] SessionDTO data)
        {
            var user = AuthHelper.GetUser(HttpContext);

            SessionDTO dbSession;
            using (var context = new DnDContext())
            {
                data.Active = false;
                data.CreatorId = user.Id;
                dbSession = context.Add(data).Entity;
                context.SaveChanges();

            }
            return dbSession;
        }
        [HttpGet(Name = "GetSessions")]
        [Authorize]
        public ActionResult<List<SessionDTO>> Get()
        {
            var user = AuthHelper.GetUser(HttpContext);


            using (var context = new DnDContext())
            {
                return context.Sessions.Where(s => s.Active || s.CreatorId == user.Id).ToList();
            }
        }
    }
}
