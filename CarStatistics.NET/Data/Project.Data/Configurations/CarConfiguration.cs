namespace Project.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Project.Data.Models;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(car => car.User)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.UserId);
        }
    }
}
