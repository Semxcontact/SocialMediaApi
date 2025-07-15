
using Microsoft.EntityFrameworkCore;
using SocialMediaApi.Models;
using SocialMediaApi.Service;
using SQLitePCL;


namespace SocialMediaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Batteries.Init();

            builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenAnyIP(5000); 
            });

            // Add services to the container.
            builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddScoped<EmailService>();
           
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
