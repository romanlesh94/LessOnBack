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
using Microsoft.EntityFrameworkCore;
using Entities.DTO;

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

        public const int LIFETIME = 100;

        public async Task<ResponseDTO> LogInAsync(AuthDTO authDTO)
        {
            var identity = await GetIdentityAsync(authDTO.Login, authDTO.Password);
            
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

            ResponseDTO response = new ResponseDTO
            { 
                Token = encodedJwt,
                Username = identity.Name,
                Country = identity.FindFirst(x => x.Type == ClaimTypes.Locality).Value,
                Email = identity.FindFirst(x => x.Type == ClaimTypes.Email).Value,

            };

            return response;
        }

        public async Task<Person> SignUpAsync(AuthDTO authDTO)
        {

            Person person = new Person { 
                Login = authDTO.Login, 
                Password = authDTO.Password, 
                Country = authDTO.Country, 
                Email = authDTO.Email,
            };
            
            await _genericRepository.CreateAsync(person);

            await this.LogInAsync(authDTO);

            return person;
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string username, string password)
        {
            var person = await (await _genericRepository.QueryAsync()).FirstOrDefaultAsync(x => x.Login == username && x.Password == password);

            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimTypes.Email, person.Email),
                    new Claim(ClaimTypes.Locality, person.Country),
                    //new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
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
