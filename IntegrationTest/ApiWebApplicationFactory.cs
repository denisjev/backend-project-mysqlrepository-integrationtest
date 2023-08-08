using System.Reflection;
using Contexts.Users.Application.DTOs;
using Contexts.Users.Domain;
using Contexts.Users.Infraestruture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegrationTest;

public class ApiWebApplicationFactory : WebApplicationFactory<Api.Api>
{   
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //builder.UseEnvironment("Testing");
        base.ConfigureWebHost(builder);
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var  MyAllowAllOrigins = "_myAllowAllOrigins";
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowAllOrigins,
                    policy  =>
                    {
                        policy.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();;
                    });
            });

            // Add services to the container.
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserDTO).Assembly));
            services.AddScoped<IUserRepository, UserRepositoryFromMySQL>();
            services.AddDbContext<AppDbContext>(options => 
                options.UseMySql("Server=localhost;Database=data;Uid=root;password=mysql",
                    new MySqlServerVersion(new Version(5,7))).EnableDetailedErrors());
        });

        return base.CreateHost(builder);
    }
}