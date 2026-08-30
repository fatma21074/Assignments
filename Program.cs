using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Task10.Validators;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
