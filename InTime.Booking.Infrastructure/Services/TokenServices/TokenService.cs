﻿using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.User;
using InTime.Booking.Infrastructure.Services.TokenServices.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InTime.Booking.Infrastructure.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public TokenService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<TokenResponse> GenerateAccessToken(BaseUser user)
        {
            var claimsIdentity = await GetClaimsIdentity(user);

            var now = DateTime.Now;
            var lifeTime = int.Parse(_configuration["Jwt:LifeTime"]);
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(lifeTime)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = await GenerateRefreshToken();
            var refreshTokenLifeTime = int.Parse(_configuration["Jwt:RefreshTokenLifeTime"]);

            return new TokenResponse("Success", "Access token created", encodedToken, refreshToken, refreshTokenLifeTime);
        }

        public Task<Guid> GetUserIdByToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var readToken = (JwtSecurityToken)jsonToken;

            var res = readToken.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;

            return Task.FromResult(Guid.Parse(res));
        }

        public async Task<TokenResponse> Refresh(BaseUser user, string refreshToken)
        {
            var authComponent = await _unitOfWork.Repository<AuthComponent>().GetById(user.AuthComponentId);

            if (authComponent.RefreshToken != refreshToken ||
            authComponent.ExpiriesDate < DateTime.Now)
            {
                var res = new TokenResponse("Fail", "Refresh token is not valid");
                return res;
            }

            var result = await GenerateAccessToken(user);

            return result;
        }

        private static Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Task.FromResult(Convert.ToBase64String(randomNumber));
        }

        private Task<ClaimsIdentity> GetClaimsIdentity(BaseUser user)
        {
            var claims = new List<Claim>();

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            var claimsIdetity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return Task.FromResult(claimsIdetity);
        }
    }
}
