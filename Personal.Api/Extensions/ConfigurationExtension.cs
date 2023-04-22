using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Personal.Api.Extensions;

public static class ConfigurationExtension
{
    
    public static IServiceCollection AddPersonalDbContext<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {

        string _connectionString = configuration.GetConnectionString("Identity");
        var _mysql = configuration.GetSection("MySql");
        Version _version = new Version(
            major : int.Parse(_mysql["Major"]),
            minor : int.Parse(_mysql["Minor"]),
            build : int.Parse(_mysql["Build"])
        );

        services.AddDbContext<T>(options => {
            options.UseMySql(_connectionString, new MySqlServerVersion(_version));
            options.EnableSensitiveDataLogging();
        });

        return services;
    }  

    public static WebApplicationBuilder AddPersonalConfiguration(this WebApplicationBuilder builder)
    {
        
        builder.Configuration.AddJsonFile(builder.Configuration["JsonFile"], false);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ListenAnyIP(int.Parse(builder.Configuration["Port"]), listen => {
                listen.UseHttps(builder.Configuration["Certificate"]);
            });
        });

        builder.Services.AddControllers().AddJsonOptions(options => {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)    
        .AddJwtBearer(options =>    
        {    
            options.TokenValidationParameters = new TokenValidationParameters    
            {    
                ValidateIssuer = true,    
                ValidateAudience = true,    
                ValidateLifetime = true,    
                ValidateIssuerSigningKey = true,    
                ValidIssuer = builder.Configuration["Domain"],    
                ValidAudience = builder.Configuration["Domain"],    
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]))    
            };    
        });

        return builder;
    }

    public static IApplicationBuilder UsePersonal(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        return app;
    }

    internal class MySQLConfiguration
    {
        public int Major {get; set;}
        public int Minor {get; set;}
        public int Build {get; set;}
    }  

}

