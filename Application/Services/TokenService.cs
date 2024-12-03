using Application.Abstractions.Services;
using Application.Exceptions;
using Application.Models.Request;
using Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services {
    public class TokenService : ITokenService {
        private readonly JwtAuthenticationOption jwtAuthenticationOption;
        private readonly IUserService userService;

        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthenticationOption, IUserService userService) {
            this.jwtAuthenticationOption = jwtAuthenticationOption.Value;
            this.userService = userService;
        }

        public async Task<string> CreateToken(CreateTokenRequest createTokenRequest)
        {

            var user = await userService.GetByEmail(createTokenRequest.Email);

            List<Claim> claims = new List<Claim> {
                new Claim("user_id", user.Id.ToString()),
                new Claim("username", user.Name),
                new Claim("surname", user.Surname),
                new Claim("email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthenticationOption.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(
                issuer: jwtAuthenticationOption.Issuer,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
