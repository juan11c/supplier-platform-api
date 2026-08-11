using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierPlatform.Domain.Entities;

namespace SupplierPlatform.Infrastructure.Persistence.Configurations;

public class SupplierProfileConfiguration : IEntityTypeConfiguration<SupplierProfile>
{
    public void Configure(EntityTypeBuilder<SupplierProfile> builder)
    {
        builder.ToTable("SupplierProfiles");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.BusinessName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(s => s.Phone)
            .HasMaxLength(20);

        builder.Property(s => s.Address)
            .HasMaxLength(250);

        builder.Property(s => s.ClaimToken)
            .HasMaxLength(100);

        // Relación 1 a 1 opcional con User
        builder.HasOne(s => s.User)
            .WithOne(u => u.SupplierProfile)
            .HasForeignKey<SupplierProfile>(s => s.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}