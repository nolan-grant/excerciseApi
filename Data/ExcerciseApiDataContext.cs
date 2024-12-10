using Microsoft.EntityFrameworkCore;

namespace ExcerciseApi.Data
{
    /// <summary>
    /// The database context.
    /// </summary>
    public class ExcerciseApiDataContext : DbContext
    {
        protected readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the data context.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        public ExcerciseApiDataContext(IConfiguration configuration) => this.configuration = configuration;

        /// <summary>
        /// The database context configuration.
        /// </summary>
        /// <param name="optionsBuilder">The builder for configuring database context options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(configuration.GetConnectionString("ExcerciseApi"));

        /// <summary>
        /// The database context model configuration.
        /// </summary>
        /// <param name="modelBuilder">The builder for configuring model options.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExcerciseDataEntityTypeConfiguration());
        }

        /// <summary>
        /// The excercise data table.
        /// </summary>
        public DbSet<ExcerciseData> ExcerciseData { get; set; }
        
    }
}
