using Entities;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Entities.Exceptions;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IGenericRepository<Person> _genericRepository;
        private readonly TokenParameters _tokenParameters;
        public AccountService(IGenericRepository<Person> genericRepository, IOptions<TokenParameters> tokenParameters)
        {
            _genericRepository = genericRepository;
            _tokenParameters = tokenParameters.Value;
        }

        public const int LIFETIME = 1;

        public object LogIn(string username, string password)
        {
            var identity = GetIdentity(username, password);
            
            if (identity == null)
            {
                throw new InvalidPasswordExc("Invalid username or password");
            }

            var now = DateTime.UtcNow;

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenParameters.IssuerSigningKey));

            var jwt = new JwtSecurityToken(
                    issuer: _tokenParameters.ValidIssuer,
                    audience: _tokenParameters.ValidAudience,
                    claims: identity.Claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(LIFETIME)),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            { 
                access_token = encodedJwt,
                username = identity.Name
            };

            return response;
        }

        public async Task<Person> SignUpAsync(string username, string password)
        {

            Person person = new Person { Login = username, Password = password };
            
            await _genericRepository.CreateAsync(person);

            return person;
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = _genericRepository.Query().FirstOrDefault(x => x.Login == username && x.Password == password);

            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
