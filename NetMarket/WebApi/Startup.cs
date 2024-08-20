using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;
using WebApi.Dtos;
using WebApi.Middleware;

namespace WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();

        var builder = services.AddIdentityCore<Usuario>();
        builder = new IdentityBuilder(builder.UserType, builder.Services);
        builder.AddRoles<IdentityRole>();

        builder.AddEntityFrameworkStores<SeguridadDbContext>();
        builder.AddSignInManager<SignInManager<Usuario>>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"])),
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidateIssuer = true,
                    ValidateAudience = false

                };
            });



        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
        services.AddScoped(typeof(IGenericSeguridadRepository<>), (typeof(GenericSeguridadRepository<>)));
        services.AddDbContext<MarketDbContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddDbContext<SeguridadDbContext>(x =>
        {
            x.UseSqlServer(Configuration.GetConnectionString("IdentitySeguridad"));
        });

        services.AddSingleton<IConnectionMultiplexer>(c =>
        {
            var configuration = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"),true);
            return ConnectionMultiplexer.Connect(configuration);
        });

        services.AddSingleton<ISystemClock, SystemClock>();

        services.AddTransient<IProductoRepository, ProductoRepository>();
        

        services.AddControllers();

        services.AddScoped<ICarritoCompraRepository, CarritoCompraRepository>();

        //para que sea consumido por clientes como react, angular, etc
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsRule", rule =>
            {
                //en el * se pueden configurar los ip
                rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
            });
         });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //if (env.IsDevelopment())
        //{
        //    app.UseDeveloperExceptionPage();
        //}
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseStatusCodePagesWithReExecute("/errors", "?code={0}");

        app.UseRouting();
        app.UseCors("CorsRule");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}

