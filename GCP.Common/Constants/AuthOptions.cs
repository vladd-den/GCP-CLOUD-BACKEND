using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCP.Common.Constants
{
    public static class AuthOptions
    {
        public const string ISSUER = "PT";
        public const string AUDIENCE = "PT";
        public const string JWT_QUERY_PARAMETER_NAME = "token";
        public const string KEY = "gTHIcLUuAMu/j5JHaN4WjRD7LABfDtT4iYCFzGJ6b2dHCkx9o4WOlPH8PP3vnKZWQ1YhoDF4A/GcuqTfK0hor/2jQyrtP2RM55bciN8/fONfBJBuvsuV8N1gxX+3mxbS";
        public const int SESSION_LIFE_TIME_DAYS = 30;
        public const int TOKEN_LIFE_TIME_MINUTES = 5;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new(Convert.FromBase64String(KEY));
        }
    }
}
