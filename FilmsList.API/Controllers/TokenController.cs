using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FilmsList.API.Models;
using FilmsList.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FilmsList.API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication ??
                throw new ArgumentNullException(nameof(authentication));
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.Authenticate(
                userInfo.Email, 
                userInfo.Password);
            
            if (result)
                return GenerateToken(userInfo);
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] RegisterModel userInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authentication.RegisterUser(
                userInfo.Email, 
                userInfo.Password);
            
            if (result)
                return Ok($"User {userInfo.Email} was create successfully");
            else
            {
                ModelState.AddModelError("Invalid Create user", "Invalid create user attempt.");
                return BadRequest(ModelState);
            }
        }


        private UserToken GenerateToken(LoginModel userInfo)
        {
            // JTI = id do token
            var claims = new []
            {
                new Claim("email", userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //gerar chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            //gerar assinatura digital do token
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //tempo expiração do token
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //Gerar token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}