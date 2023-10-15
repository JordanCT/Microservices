using BCP.Muchik.Invoicement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCP.Muchik.Invoicement.Infrastructure.Configurations
{
    public class InvoiceEntityTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).HasColumnName("id_invoice");
            builder.Property(e => e.Amount).HasColumnName("amount");
            builder.Property(e => e.State).HasColumnName("state");
        }
    }
}
