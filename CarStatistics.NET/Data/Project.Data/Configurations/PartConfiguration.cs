namespace Project.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Project.Data.Models;

    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder
                .HasOne(p => p.Repair)
                .WithMany(rp => rp.Parts)
                .HasForeignKey(p => p.RepairId);
        }
    }
}
