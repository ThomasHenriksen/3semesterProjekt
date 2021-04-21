using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
