using GCP.Common.Constants;
using GCP.Common.UIModels.ResponseModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GCP.Common.Helpers
{
    public static class TokenResultHelper
    {
        private const string SECRET = AuthOptions.KEY;

        private static TokenResult GenerateToken(
            SecurityTokenDescriptor tokenDescriptor,
            DateTime expireDate
            )
        {
            JwtSecurityTokenHandler tokenHandler = new();

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return new TokenResult
            {
                TokenModel = new TokenResponseModel
                {
                    Token = token,
                    ExpireDate = expireDate
                }
            };
        }

        public static TokenResult InternalGenerateToken(
            Guid userId,
            Guid refreshToken,
            DateTime expireRefreshDate,
            string userName,
            string userRole
            )
        {
            HashSet<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Jti, refreshToken.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, AuthOptions.AUDIENCE)
            };

            if (!string.IsNullOrWhiteSpace(userName))
            {
                claims.Add(new Claim(ClaimTypes.Name, userName));
            }

            if (!string.IsNullOrWhiteSpace(userRole))
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            byte[] symmetricKey = Convert.FromBase64String(SECRET);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = AuthOptions.ISSUER,
                Subject = new ClaimsIdentity(claims),
                Expires = expireRefreshDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            return GenerateToken(tokenDescriptor, expireRefreshDate);
        }

        public static TokenResult InvalidAccessTokenFormat => new()
        {
            Error = "Invalid access token format",
            ErrorDescription = "Invalid access token format"
        };

        public static TokenResult InvalidAccessTokenBody => new()
        {
            Error = "Invalid access token body",
            ErrorDescription = "Invalid access token body"
        };

        public static TokenResult ExpiredAccessToken => new()
        {
            Error = "Access token has expired or session not exists",
            ErrorDescription = "Access token has expired or session not exists"
        };

        public static TokenResult InvalidEmailOrPassword => new()
        {
            Error = "Email or password is incorrect.",
            ErrorDescription = "Email or password is incorrect."
        };

        public static TokenResult ActivationRequired => new()
        {
            Error = "Account required activation.",
            ErrorDescription = "Account required activation."
        };

        public static TokenResult InvalidTwoFACodeId => new()
        {
            Error = "Invalid Two-Factor Authentication code ID",
            ErrorDescription = "Invalid Two-Factor Authentication code ID"
        };

        public static TokenResult InvalidTwoFACode => new()
        {
            Error = "The entered security code is invalid or expired. Please try again.",
            ErrorDescription = "The entered security code is invalid or expired. Please try again."
        };

        public static TokenResult UserNotFound => new()
        {
            Error = "User is not found",
            ErrorDescription = "User is not found"
        };
    }
}
