using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infra.Data.Map
{
    internal class PersonMap : IEntityTypeConfiguration<Domain.ExampleAggregate.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.Person> orderConfiguration)
        {
            orderConfiguration.ToTable("Pessoa", "dbo")
                .HasKey(p => p.Id);

            orderConfiguration
                .Property(p => p.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            orderConfiguration
                .Property(p => p.Name)
                .HasColumnName("Nome");

            orderConfiguration
                .Property(p => p.Document)
                .HasColumnName("CPF");

            orderConfiguration
                .Property(p => p.Age)
                .HasColumnName("Idade");

            orderConfiguration
                .Property(p => p.CityId)
                .HasColumnType("Id_Cidade");

            orderConfiguration
                .HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.CityId);
        }
    }
}
