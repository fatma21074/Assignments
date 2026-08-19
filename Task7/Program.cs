using Microsoft.EntityFrameworkCore;
using Task7.ApplicationDbcontext;
using Task7.Repo;
using Task7.Repo.Interface;
using Task7.Services;
using Task7.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer( builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUserRpo,UserRepo>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ITaskItemsRepo,TaskItemRepo>();
builder.Services.AddScoped<ITaskItemService,TaskItemService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
