using BCP.Muchik.Payment.Domain.Entities;
using BCP.Muchik.Payment.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BCP.Muchik.Payment.Infrastructure.Context
{
    public partial class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pay> Order { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PayEntityTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
