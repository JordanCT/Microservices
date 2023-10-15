using BCP.Muchik.Invoicement.Domain.Entities;
using BCP.Muchik.Invoicement.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BCP.Muchik.Invoicement.Infrastructure.Context
{
    public partial class InvoicementContext : DbContext
    {
        public InvoicementContext(DbContextOptions<InvoicementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoice { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceEntityTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
