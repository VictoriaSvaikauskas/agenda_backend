using AgendaAPI.Data.Repository;
using AgendaAPI.DTOs;
using AgendaAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository { get; set; }
        private readonly IConfiguration _config;
        public UserController(UserRepository userRepository, IConfiguration config) 
        {
            _userRepository = userRepository;
            _config = config;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpGet]
        [Route("GetOne/{Id}")]
        public IActionResult GetOneById(int Id)
        {
            List<User> usersToReturn = _userRepository.GetAllUsers();
            usersToReturn.Where(x => x.Id == Id).ToList();
            if(usersToReturn.Count > 0)
                return Ok(usersToReturn);
            return NotFound("Usuario inexistente");
        }

        [HttpPost]
        public IActionResult CreatUser(UserForCreationDTO userDTO)
        {
            _userRepository.CreateUser(userDTO);
            return NoContent();
        }

        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<string> Auth(AuthenticationRequestBody authDto)
        {
            // Verificamos credenciales
            var user = _userRepository.Validate(authDto.UserName, authDto.Password);

            if (user is null)
            {
                return Forbid(); //si nos devuelve nulo significa que el usuario no existe o la pass está mal
            }

            // Generamos un token según los claims
            var claims = new List<Claim>
    {
        new Claim("id", user.Id.ToString()),
        new Claim("username", user.UserName),
        new Claim("fullname", $"{user.Name} {user.LastName}")
    };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(new
            {
                AccessToken = jwt
            });
        }
    }
}
