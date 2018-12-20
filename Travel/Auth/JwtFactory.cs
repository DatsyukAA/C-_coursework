using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Travel.Helpers;

namespace Travel.Auth
{
    public class JwtFactory
    {
        private readonly JwtIssuerOptions jwtOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions )
        {
            this.jwtOptions = jwtOptions.Value;
        }

        public string GenerateEncodedToken(string userName, ClaimsIdentity claimsIdentity)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat,Math.Round((jwtOptions.IssuedAt.ToUniversalTime() - new DateTimeOffset(1970,1,1,0,0,0,TimeSpan.Zero)).TotalSeconds).ToString(),ClaimValueTypes.Integer),
                claimsIdentity.FindFirst(Constants.JwtClaimIndentifiers.Role),claimsIdentity.FindFirst(Constants.JwtClaimIndentifiers.Id)
            };

            var jwt = new JwtSecurityToken
            (
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                notBefore: jwtOptions.NotBefore,
                expires: jwtOptions.Expiration,
                signingCredentials: jwtOptions.SigningCredentals
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        public static string GenerateJwt(ClaimsIdentity identity, JwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                id = identity.Claims.SingleOrDefault(c => c.Type == "id").Value,
                rol = identity.Claims.SingleOrDefault(c => c.Type == "rol").Value,
                auth_token = jwtFactory.GenerateEncodedToken(userName, identity),
                expires_in = (int)jwtOptions.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }

        public ClaimsIdentity GenerateClaimsIdentity(string userName, int id,string role)
        {
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim(Constants.JwtClaimIndentifiers.Id,id.ToString()),
                new Claim(Constants.JwtClaimIndentifiers.Role, role)
            });
        }
    }
}
