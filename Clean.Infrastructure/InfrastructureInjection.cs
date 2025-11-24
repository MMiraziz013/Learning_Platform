using Clean.Application.Abstractions;
using Clean.Infrastructure.Data;
using Clean.Infrastructure.Data.Repositories;
using Clean.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Infrastructure;

public static class InfrastructureInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        var baseConnectionString = configuration.GetConnectionString("DefaultConnection");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var builder = new Npgsql.NpgsqlConnectionStringBuilder(baseConnectionString);

        if (!string.IsNullOrEmpty(dbPassword))
        {
            builder.Password = dbPassword;
        }

        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(builder.ConnectionString));

        services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());

        services.AddTransient<IDataSeeder, IdentitySeeder>();
        services.AddTransient<IDataSeeder, SeedAdminUser>();
        services.AddTransient<SeedDataInitializer>();


        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }
}