using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EventProject.Persistence.Data;
using Microsoft.Extensions.Configuration;

namespace EventProject.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory()) 
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

           
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
