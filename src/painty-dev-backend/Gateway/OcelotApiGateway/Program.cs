using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add services
builder.Services.AddOcelot(builder.Configuration).AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});

// Authentication (current: JWT)
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
        };
    });

// CORS
builder.Services.AddCors(o => o.AddPolicy("Freepolicy", builder =>
{
    builder.WithOrigins("https://localhost")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Freepolicy");

await app.UseOcelot();

app.Run();
