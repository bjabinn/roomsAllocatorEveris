using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using APISalasEveris.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace APISalasEveris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenGeneratorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly RoomContext _context;

        public TokenGeneratorController(RoomContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("token/{serializer}")]
        public string GenerateToken(string serializer)
        {
            var claims = new[]
           {
            new Claim("UserData",serializer)
        };
            var token = new JwtSecurityToken
        (
            issuer: _configuration["ApiAuth:Issuer"],
            audience: _configuration["ApiAuth:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(60),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApiAuth:SecretKey"])),
            SecurityAlgorithms.HmacSha256)
        );

            string stringToken=new JwtSecurityTokenHandler().WriteToken(token);
            return stringToken;
        }
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                TokenValidationParameters parameters = GetValidationParameters();
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public  TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = _configuration["ApiAuth:Issuer"],
                ValidAudience = _configuration["ApiAuth:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApiAuth:SecretKey"])) // The same key as the one that generate the token
            };
        }
        public string tokenClaims(string token)
        {
            string userData = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim userDataClaim = identity.FindFirst("UserData");
            userData = userDataClaim.Value;
            return userData;
        }
        [HttpGet]
        public bool Validate(string token, string userData)
        {
            TokenGeneratorController tgc = new TokenGeneratorController(_context, _configuration);
            string tokenUserData = tgc.tokenClaims(token);
            return userData.Equals(tokenUserData);
        }

    }
}