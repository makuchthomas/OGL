using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OGL.Infrastructure.DTO;
using OGL.Infrastructure.Extensions;
using OGL.Infrastructure.Settings;

namespace OGL.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {

        private readonly JwtSettings _jwtSettings;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly SigningCredentials _signingCredentials;
        private readonly TokenValidationParameters _tokenValidationParameters;
        public JwtHandler(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            _signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

            _tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = issuerSigningKey,
                ValidIssuer = _jwtSettings.Issuer
            };
        }

        public JwtDto Createtoken(string email, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };
            /*
            if (claims != null)
            {
                foreach (var claim in claims)
                {
                    claims.Add(new Claim(claim.Key, claim.Value));
                }
            }
            */
            var expiry = now.AddMinutes(_jwtSettings.ExpiryMinutes);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)), SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken
            (
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expiry,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                Expires = expiry.ToTimestamp()
            };
        }

    }
}
