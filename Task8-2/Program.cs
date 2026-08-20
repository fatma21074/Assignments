using Microsoft.EntityFrameworkCore;
using Task9.ApplicationDbcontext;
using Task9.Repo;
using Task9.Repo.Interface;
using Task9.Services;
using Task9.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer( builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ITaskRepository,TaskRepository>();
builder.Services.AddScoped<ITaskItemService,TaskItemService>();
builder.Services.AddAutoMapper(typeof(Task9.Mapping.MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
