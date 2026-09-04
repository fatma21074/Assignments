using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Task12.Authorization;
using Task12.Data;
using Task12.Repistories;
using Task12.Repistories.Interfaces;
using Task12.Services;
using Task12.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ITaskRepistory, TaskRepistory>();
builder.Services.AddScoped<ITaskServices, TaskServices>();

builder.Services.AddScoped<IUserRepistory, UserRepistory>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAuthorizationHandler, TaskAuthorizationHandler>();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Secret"]!))
        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ITAdmin", policy =>
        policy.RequireAuthenticatedUser()
              .RequireRole("Admin")
              .RequireClaim("Department", "IT")
              );
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
