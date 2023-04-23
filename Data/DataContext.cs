using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameX1API.Data { }

public class DataContext : DbContext
{
    protected readonly IConfigurationRoot configuration;

    public DataContext()
    {
        configuration = new ConfigurationBuilder()
        .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer(configuration.GetConnectionString("GameX1"));

    public DbSet<Picture> Picture { get; set; }

    public DbSet<AdminUser> AdminUser{ get; set; }
}

