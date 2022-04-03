using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infra.Data.Map
{
    internal class CityMap : IEntityTypeConfiguration<Domain.ExampleAggregate.City>
    {
        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.City> orderConfiguration)
        {
            orderConfiguration.ToTable("City", "dbo")
                .HasKey(p => p.Id);

            orderConfiguration
                .Property(p => p.Id)
                .UseIdentityColumn();

            orderConfiguration
                .Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            orderConfiguration
                .Property(p => p.State)
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
