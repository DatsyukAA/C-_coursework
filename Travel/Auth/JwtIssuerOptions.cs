using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace Travel.Auth
{
    public class JwtIssuerOptions
    {
        public string Issuer { get; set; }

        public string Subject { get; set; }

        public string Audience { get; set; }

        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public DateTime NotBefore => DateTime.UtcNow;

        public DateTime IssuedAt => DateTime.UtcNow;

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(5);

        public Func<string> JtiGenerator =>
            () => Guid.NewGuid().ToString();

        public SigningCredentials SigningCredentals { get; set; }
    }
}
