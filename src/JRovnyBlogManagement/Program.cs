using JRovny.BlogManagement;
using JRovny.BlogManagement.Data;
using JRovny.BlogManagement.Data.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);
var section = builder.Configuration.GetSection("ApplicationSettings");
var authority = section.GetValue<string>("authority");
var audience = section.GetValue<string>("audience");

builder.Host.UseSerilog((context, logger) =>
{
    var isDevelopment = context.HostingEnvironment.IsDevelopment();
    logger.WriteTo.Console()
    .WriteTo.File(new JsonFormatter(),
        isDevelopment ? @".\log\log-.txt" : @"./log/log-.txt",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: null,
        rollOnFileSizeLimit: true);
});

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<PostsDataProvider>();
builder.Services.AddTransient<ImagesDataProvider>();
builder.Services.Configure<ApplicationSettings>(section);

builder.Services.AddControllersWithViews();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "dist";
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("IdentityServer", policy =>
    {
        policy.WithOrigins(authority)
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = authority;
        options.Audience = audience;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = true
        };
    });

var app = builder.Build();

app.UseSpaStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("IdentityServer");
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
    }
});

app.Run();
