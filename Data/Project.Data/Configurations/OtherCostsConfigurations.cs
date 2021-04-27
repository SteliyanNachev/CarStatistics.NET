namespace Project.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Project.Data.Models;

    public class OtherCostsConfigurations : IEntityTypeConfiguration<OtherCosts>
    {
        public void Configure(EntityTypeBuilder<OtherCosts> builder)
        {
            builder
                .HasOne(oc => oc.Car)
                .WithMany(c => c.OtherCosts)
                .HasForeignKey(oc => oc.CarId);
        }
    }
}
