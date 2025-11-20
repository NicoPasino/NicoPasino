using dotenv.net;
using Microsoft.EntityFrameworkCore;
using NicoPasino.Core.Interfaces;
using NicoPasino.Infra.Data;
using NicoPasino.Infra.Repositorio;
using NicoPasino.Servicios.Servicios.Movies;

namespace NicoPasino
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            // conexion
            /* SQL Server
             * builder.Services.AddDbContext<moviesdbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesConnectionString"))
            );*/
            DotEnv.Load(); // del paquete dotenv.net
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection2");
            builder.Services.AddDbContext<moviesdbContext>(options =>
            options.UseMySql(
                connectionString, new MySqlServerVersion(new Version(8, 0, 39))
            ));

            // permitir inyeccion
            builder.Services.AddScoped<IMovieServicio, MovieServicio>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            var app = builder.Build();

            // crear una base de datos a travez de una migracion
            /*using (var scope = app.Services.CreateScope()) {
                var context = scope.ServiceProvider.GetRequiredService<moviesdbContext>();
                context.Database.Migrate();
            }*/

            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
