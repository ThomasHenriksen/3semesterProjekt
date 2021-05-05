using ArmysalgDataAccess.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArmysalgService.Controllers
{
    public class TokensController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokensController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
        }

        [Route("/token")]
        [HttpPost]

        public IActionResult Create([FromForm] string username, string password, string grantType)
        {
            bool hasInput = ((!String.IsNullOrWhiteSpace(username)) && (!String.IsNullOrWhiteSpace(password)));
            SecurityHelper secUtil = new SecurityHelper(_configuration);
            if (hasInput && secUtil.IsValidUsernameAndPassword(username, password))
            {
                string jwtToken = GenerateToken(username, grantType);
                return new ObjectResult(jwtToken);
            }
            else
            {
                return BadRequest();
            }
        }

        private string GenerateToken(string username, string grantType)
        {
            string tokenString = null;
            int ttlInMinutes = 10; 
            SecurityHelper secUtil = new SecurityHelper(_configuration);
            SymmetricSecurityKey SIGNING_KEY = secUtil.GetSecurityKey();
            SigningCredentials credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);
            JwtHeader header = new JwtHeader(credentials);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),                
                new Claim(ClaimTypes.Role, grantType),
                new Claim(JwtRegisteredClaimNames.Nbf, 
                new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,
                new DateTimeOffset(DateTime.Now.AddMinutes(ttlInMinutes)).ToUnixTimeSeconds().ToString())            
            };
            JwtPayload payload = new JwtPayload(claims);
            JwtSecurityToken secToken = new JwtSecurityToken(header, payload);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            tokenString = handler.WriteToken(secToken);
            return tokenString;
        }
    }
}