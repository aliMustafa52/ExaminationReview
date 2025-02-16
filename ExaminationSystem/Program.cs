
using ExaminationSystem.Persistence;
using ExaminationSystem.Services.Questions;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //Add EF
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            //    ?? throw new InvalidOperationException("connectionString name DefaultConnection is not found");

            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(connectionString);
            //});

            //register services
            //builder.Services.AddScoped<IQuestionService, QuestionService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
