using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infra.Data.Map
{
    internal class PersonMap : IEntityTypeConfiguration<Domain.ExampleAggregate.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.Person> orderConfiguration)
        {
            orderConfiguration.ToTable("Person", "dbo")
                .HasKey(p => p.Id);

            orderConfiguration
                .Property(p => p.Id)
                .UseIdentityColumn();

            orderConfiguration
                .Property(p => p.Name)
                .HasMaxLength(300)
                .IsRequired();

            orderConfiguration
                .Property(p => p.Document)
                .HasMaxLength(11)
                .IsRequired();

            orderConfiguration
                .Property(p => p.Age)
                .IsRequired();

            orderConfiguration
                .Property(p => p.CityId)
                .IsRequired(); ;

            orderConfiguration
                .HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.CityId);
        }
    }
}
