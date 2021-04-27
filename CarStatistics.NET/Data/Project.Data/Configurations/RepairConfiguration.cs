namespace Project.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Project.Data.Models;

    public class RepairConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder
                .HasOne(r => r.Car)
                .WithMany(c => c.Repairs)
                .HasForeignKey(r => r.CarID);
            builder
                .HasOne(r => r.RepairShop)
                .WithMany(reparshop => reparshop.Repairs)
                .HasForeignKey(r => r.RepairShopId);
        }
    }
}
