using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ArmysalgDataAccess.Security
{
    public class SecurityHelper
    {
        private readonly IConfiguration _configuration;

        // Fetches configuration from more sources
        public SecurityHelper(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
        }

        // Create key for signing
        public SymmetricSecurityKey GetSecurityKey()
        {
            string SECRET_KEY = _configuration["SECRET_KEY"];
            SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            return SIGNING_KEY;
        }

        // Validet the username and password from app setting
        public bool IsValidUsernameAndPassword(string username, string password)
        {
            string allowedUsername = _configuration["AllowDesktopApp:Username"];
            string allowedPassword = _configuration["AllowDesktopApp:Password"];
            bool credentialsOk = (username.Equals(allowedUsername)) && (password.Equals(allowedPassword));
            return credentialsOk;
        }
    }
}
