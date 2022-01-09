
using DnDCharacterManager.Constants;
using DnDCharacterManager.Models.DTO;
using DnDCharacterManager.Util;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public class AuthenticateRequest
        {
            [Required]
            public string IdToken { get; set; }
        }

        private readonly JwtGenerator _jwtGenerator;

        public UserController(IConfiguration configuration)
        {
            _jwtGenerator = new JwtGenerator(configuration);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest data)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

            // Change this to your google client ID
            settings.Audience = new List<string>() { "313667029932-l7ners2v38n8jhlp1huj6dv74ivq4g9b.apps.googleusercontent.com" };
            GoogleJsonWebSignature.Payload payload;
            try
            {
                payload = GoogleJsonWebSignature.ValidateAsync(data.IdToken, settings).Result;

            }
            catch (InvalidJwtException)
            {
                return BadRequest("No Valid Google User");
            }

            var user = CreateOrGetUser(payload);

            return Ok(new { AuthToken = _jwtGenerator.Generate(user)});
        }

        private UserDTO  CreateOrGetUser(GoogleJsonWebSignature.Payload payload)
        {
            using (var context = new DnDContext())
            {
                var user = context.Users.FirstOrDefault(user => user.GoogleID == payload.Subject);
                if (user != default)
                {
                    return user;
                }
                var newUser = context.Add(new UserDTO() { GoogleID = payload.Subject , Name = payload.Name , Role = Constants.Roles.PLAYER}).Entity;
                context.SaveChanges();
                return newUser;
            }
        }
    }
}