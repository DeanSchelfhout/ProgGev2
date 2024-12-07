using GymTestBL.Interfaces;
using GymTestBL.Services;
using GymTestDL;
using GymTestDL.Repositories;

namespace GymTestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:5173") // Gebruik de juiste URL (http of https)

                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            builder.Services.AddDbContext<GymTestContext>();
            builder.Services.AddScoped<IMemberRepository, MemberRepositoryEF>();
            builder.Services.AddScoped<MemberService>();
            builder.Services.AddScoped<IEquipmentRepository, EquipmentRepositoryEF>();
            builder.Services.AddScoped<EquipmentService>();


            // Voeg hier de JsonOptions toe om circulaire referenties te ondersteunen
            builder.Services.AddControllers();

            // Add services to the container
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Use CORS middleware before authorization
            app.UseCors("AllowReactApp");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}