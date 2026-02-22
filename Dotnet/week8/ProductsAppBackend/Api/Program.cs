using System.Text;
using Application.Dtos;

using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ── 1. DbContext — connects to SQL Server ──────────────────
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration
                    .GetConnectionString("ProductConnectionName")));

            // ── 2. JWT Settings — reads from appsettings.json ──────────
            var jwtSettings = new JwtSettings
            {
                Key = builder.Configuration["Jwt:Key"]!,
                Issuer = builder.Configuration["Jwt:Issuer"]!,
                Audience = builder.Configuration["Jwt:Audience"]!
            };
            builder.Services.AddSingleton(jwtSettings);

            // ── 3. Repository registration ─────────────────────────────
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // ── 4. Service registration ────────────────────────────────
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            // ── 5. JWT Authentication ──────────────────────────────────
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                                                       Encoding.UTF8.GetBytes(jwtSettings.Key))
                    };
                });

            // ── 6. Controllers ─────────────────────────────────────────
            builder.Services.AddControllers();

            // ── 7. Swagger ─────────────────────────────────────────────
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ── 8. CORS — allows Angular on port 4200 to call this API ─
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // ── HTTP pipeline ──────────────────────────────────────────
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // ⚠️ Order matters — Cors → Authentication → Authorization
            app.UseCors("AllowAngular");
            app.UseAuthentication();   // ← NEW must be before UseAuthorization
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}