using AuthApi.Application.Dtos;
using AuthApi.Application.Interfaces;
using AuthApi.Domain.Entities;
using AuthApi.Infras.Data;
using eCommerce.SharedLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.Infras.Repositories
{
    public class UserRepository(AuthenticationDbContext _dbContext, IConfiguration config) : IUser
    {
        private async Task<AppUser> GetUserByEmail(string Email)
        {
            var user = await _dbContext.AppUsers.FirstOrDefaultAsync(U => U.Email == Email);
            return user is null ? null! : user!;
        }

        public async Task<GetUserDto> GetUser(int userId)
        {
            var user = await _dbContext.AppUsers.FindAsync(userId);
            return user is not null ? new GetUserDto(
                    user.Name!,
                    user.TelephoneNumber!,
                    user.Address!,
                    user.Email!,
                    user.Password!,
                    user.Role!
                ) : null!;
        }

        public async Task<Response> Login(LoginDto loginDto)
        {
            var getUser = await GetUserByEmail(loginDto.Email);
            if (getUser is null)
            {
                return new Response(false, $"Invalid Credentials");
            }

            bool verifyPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, getUser.Password);
            if (!verifyPassword)
            {
                return new Response(false, $"Invalid Credentials");
            }

            string token = GenerateToken(getUser);
            return new Response(true, token);
        }

        private string GenerateToken(AppUser user)
        {
            var key = Encoding.UTF8.GetBytes(config.GetSection("Authentication:Key").Value!);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name!),
                new(ClaimTypes.Email, user.Email!),
                
            };

            if (!string.IsNullOrEmpty(user.Role) || !Equals("string", user.Role))
            {
                claims.Add(new(ClaimTypes.Role, user.Role!));
            }

            var token = new JwtSecurityToken(
                issuer: config["Authentication:Issuer"],
                audience: config["Authentication:Audience"],
                claims: claims,
                expires: null,
                signingCredentials: credentials
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Response> Register(AppUserDto appUserDto)
        {
            var getUser = await GetUserByEmail(appUserDto.Email);
            if (getUser is not null)
            {
                return new Response(false, $"You cannot use this email for registration");
            }

            var result = _dbContext.AppUsers.Add(new AppUser()
            {
                Name = appUserDto.Name,
                Email = appUserDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(appUserDto.Password),
                TelephoneNumber = appUserDto.TelephoneNumber,
                Address = appUserDto.Address,
                Role = appUserDto.Role,
            });

            await _dbContext.SaveChangesAsync();
            return result.Entity.Id > 0 ? new Response(true, "User Registered successfully.") : new Response(false, "Invalid data provided");
        }
    }
}
