using JRovnySiteManager.Data;
using JRovnySiteManager.Data.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JRovnySiteManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddTransient<PostsDataProvider>();
            builder.Services.AddTransient<ImagesDataProvider>();
            builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));
            builder.Services.AddControllersWithViews();
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "dist";
            });

            var app = builder.Build();

            // app.UseHttpsRedirection();

            // app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (app.Environment.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            //app.MapRazorPages();

            app.Run();
        }
    }
}
