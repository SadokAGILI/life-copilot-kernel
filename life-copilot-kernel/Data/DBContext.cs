using life_copilot_kernel.Models;
using Microsoft.EntityFrameworkCore;
using Action = life_copilot_kernel.Models.Action;

namespace life_copilot_kernel.Data
{
    public class DBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("PGConnection"),
                  npgsqlOptions =>
                  {
                      // Set the command timeout to 10 seconds
                      npgsqlOptions.CommandTimeout(10);

                      // Enable retry on failure with specified parameters
                      npgsqlOptions.EnableRetryOnFailure(
                          maxRetryCount: 4,  // Maximum number of retries
                          maxRetryDelay: TimeSpan.FromSeconds(3),  // Maximum delay between retries
                          errorCodesToAdd: null  // List of PostgreSQL error codes to consider for retry
                      );
                  });
        }
        public DbSet<Action> Actions => Set<Action>();
    }
}
