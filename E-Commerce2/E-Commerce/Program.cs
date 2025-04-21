
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presestance;
using Presestance.Data;
using Presestance.Repositories;
using Services;
using Services.Abstractions;

namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Services

         
            //Data Seeding
            builder.Services.AddScoped<IDbInitilaizer, DbInitilaizer>();

            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(AssmbleRef).Assembly);
            builder.Services.AddScoped<IServiceManager, ServiceManager>();

            #endregion

            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //
            await InitializeDB(app);//Initialize Database




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


            //Function To Initialize Database
            async Task InitializeDB(WebApplication app)
            {
                //Create Obj From DbInitilaizer
                using var scope = app.Services.CreateScope();
                var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbInitilaizer>();
                await dbIntializer.IntilizerAsync();//Initialize Database inside it function seeding
            }



        }
    }
}
