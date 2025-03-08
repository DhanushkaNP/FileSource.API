using FileSource.Models.Entities.Customers;
using FileSource.Models.Entities.Licenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileSource.Infrastructure.Persistence.EntityConfigurations
{
    public class LicenseConfigurations : IEntityTypeConfiguration<License>
    {
        public void Configure(EntityTypeBuilder<License> builder)
        {
            builder.ToTable(nameof(License));

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedNever();

            builder.HasOne(i => i.Customer)
                .WithMany(i => i.Licenses);
        }
    }
}
