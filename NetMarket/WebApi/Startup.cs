using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
        services.AddDbContext<MarketDbContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddDbContext<SeguridadDbContext>(x =>
        {
            x.UseSqlServer(Configuration.GetConnectionString("IdentitySeguridad"));
        });
      


        services.AddTransient<IProductoRepository, ProductoRepository>();
        

        services.AddControllers();
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

