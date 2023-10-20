using BCP.Muchik.Payment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCP.Muchik.Payment.Infrastructure.Configurations
{
    public class PayEntityTypeConfiguration : IEntityTypeConfiguration<Pay>
    {
        public void Configure(EntityTypeBuilder<Pay> builder)
        {
            builder.ToTable("operation");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).HasColumnName("id_operation");
            builder.Property(e => e.InvoiceId).HasColumnName("id_invoice");
            builder.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date_modified");
        }
    }
}
