using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExcerciseApi.Data
{
    /// <summary>
    /// Configuration for the excercise data table.
    /// </summary>
    public class ExcerciseDataEntityTypeConfiguration : IEntityTypeConfiguration<ExcerciseData>
    {
        /// <summary>
        /// Performs the configuration of the data table.
        /// </summary>
        /// <param name="entity">The entity model to be configured.</param>
        public void Configure(EntityTypeBuilder<ExcerciseData> entity)
        {
            entity.ToTable("data");
            entity.HasKey(e => new { e.CustomerId, e.EventDate });
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.CoverThickness).HasColumnName("cover_thickness");
        }
    }
}
