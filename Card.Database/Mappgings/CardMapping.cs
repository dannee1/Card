using Card.Domain.Entities.CardAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Card.Database.Mappgings
{

    public class CardMapping : IEntityTypeConfiguration<CustomerCard>
    {
        public void Configure(EntityTypeBuilder<CustomerCard> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.CustomerId)
                .HasColumnName("CustomerId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(o => o.CardNumber)
                .HasColumnName("CardNumber")
                .HasColumnType("bigint")
                .IsRequired();

            builder.Property(o => o.RegistrationDate)
                .HasColumnName("RegistrationDate")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(o => o.Cvv)
                .HasColumnName("Cvv")
                .HasColumnType("int")
                .IsRequired();

        }
    }
}