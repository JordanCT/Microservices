using BCP.Muchik.Security.Domain.Entities;
using BCP.Muchik.Security.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Muchik.Security.Infrastructure.Context
{
    public partial class SecurityContext : DbContext
    {
        public SecurityContext()
        {
        }
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
