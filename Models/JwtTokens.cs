using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithJWT_App.Models
{
    public class JwtTokens
    {
        public const string Issuer = "CodersLab";
        public const string Audience = "APIUser";
        public const string Key = "1234567890123456";

        public const string AuthSchemes =
            "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}
