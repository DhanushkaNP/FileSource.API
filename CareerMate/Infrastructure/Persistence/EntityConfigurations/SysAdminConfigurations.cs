using FileSource.Models.Entities.SysAdmins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerMate.Infrastructure.Persistence.EntityConfigurations
{
    public class SysAdminConfigurations : IEntityTypeConfiguration<SysAdmin>
    {
        public void Configure(EntityTypeBuilder<SysAdmin> builder)
        {
            builder.ToTable(nameof(SysAdmin));

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedNever();

            builder.HasOne(i => i.ApplicationUser)
                .WithOne(i => i.SysAdmin)
                .HasForeignKey<SysAdmin>(i => i.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
