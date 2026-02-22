using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUserRepository userRepository, JwtSettings jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
        }

        // ── Register ───────────────────────────────────────────────────
        public async Task<AuthResponseDto?> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
                return null;  // email already taken

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role = dto.Role
            };

            var created = await _userRepository.CreateAsync(user);
            var token = GenerateToken(created);

            return new AuthResponseDto
            {
                Token = token,
                Name = created.Name,
                Email = created.Email,
                Role = created.Role
            };
        }

        // ── Login ──────────────────────────────────────────────────────
        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var passwordHash = HashPassword(dto.Password);

            var user = await _userRepository
                .GetByEmailAndPasswordAsync(dto.Email, passwordHash);

            if (user == null) return null;

            var token = GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        // ── Hash Password ──────────────────────────────────────────────
        private string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        // ── Generate JWT Token ─────────────────────────────────────────
        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,           user.Name),
                new Claim(ClaimTypes.Email,          user.Email),
                new Claim(ClaimTypes.Role,           user.Role)
            };

            var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}