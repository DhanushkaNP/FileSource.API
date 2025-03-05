using FileSource.Models.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileSource.Infrastructure.Persistence.EntityConfigurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedNever();

            builder.HasOne(i => i.ApplicationUser)
                .WithOne(i => i.Customer)
                .HasForeignKey<Customer>(i => i.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
