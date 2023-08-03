using CalendarBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CalendarBlazorApp.Service
{
    public class DayEventDbContext : DbContext
    {
        public DayEventDbContext(DbContextOptions options) : base(options)
        {
        }

        public DayEventDbContext()
        {
        }

        public DbSet<DayEvent> DayEvent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.LogTo(message => Debug.WriteLine(message))
                    .EnableSensitiveDataLogging();

                optionsBuilder
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                optionsBuilder.
                    UseSqlServer("Data Source=LENOVO_JOSE;Initial Catalog=PracticeDb;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DayEvent>(
                entity =>
                {
                    entity.ToTable("DayEventTable");
                    entity.HasKey(e => e.DayEventID);
                    entity.Property(e => e.DayEventID);

                    entity.Property(e => e.Note).IsRequired(required: false);

                    entity.Property(e => e.FromDate).HasColumnType("datetime");

                    entity.Property(e => e.ToDate).HasColumnType("datetime");
                }
                );
        }
    }
}
