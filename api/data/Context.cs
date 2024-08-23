using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace api.data
{
    public class ApplicationDbContext : DbContext
    {

        private void ApplyDateTimeConversion(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                if (clrType == null) continue;

                var properties = clrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.Name).Property<DateTime>(property.Name)
                            .HasConversion(
                                v => TreatDate(v),
                                v => TreatDateRead(v)
                            );
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.Name).Property<DateTime?>(property.Name)
                            .HasConversion(
                                v => TreatDate(v),
                                v => TreatDateRead(v)
                            );
                    }
                }
            }
        }
        private DateTime TreatDate(DateTime date)
        {
            return date.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(date, DateTimeKind.Utc).ToUniversalTime()
                : date.ToUniversalTime();
        }

        private DateTime TreatDateRead(DateTime date)
        {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }

        private DateTime? TreatDate(DateTime? date)
        {
            if (!date.HasValue)
                return null;

            return date.Value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(date.Value, DateTimeKind.Utc).ToUniversalTime()
                : date.Value.ToUniversalTime();
        }

        private DateTime? TreatDateRead(DateTime? date)
        {
            return date.HasValue ? DateTime.SpecifyKind(date.Value, DateTimeKind.Utc) : (DateTime?)null;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CertificateGlossaryEntryMapping());
            modelBuilder.ApplyConfiguration(new FunctionPointsMapping());
            modelBuilder.ApplyConfiguration(new GlossaryEntryMapping());
            modelBuilder.ApplyConfiguration(new CertificateMapping());
            modelBuilder.ApplyConfiguration(new ServiceHoursMapping());

            ApplyDateTimeConversion(modelBuilder);
        }
    }
}
