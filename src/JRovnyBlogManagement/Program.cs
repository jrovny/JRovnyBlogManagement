using JRovny.BlogManagement;
using JRovny.BlogManagement.Data;
using JRovny.BlogManagement.Data.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
builder.Services.AddCors(options =>
{
    options.AddPolicy("IdentityServer", policy =>
    {
        policy.WithOrigins("https://test.accounts.jrovny.com")
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://test.accounts.jrovny.com";
        options.Audience = "https://localhost:5001/api";
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
