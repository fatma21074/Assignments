using Task4.Repo;
using Task4.Repo.Interface;
using Task4.Service;
using Task4.Service.Interface;
using Task4.MiddelWare;
namespace Task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();
            
            app.UseMiddleware<GlobalExceptionHandler>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
