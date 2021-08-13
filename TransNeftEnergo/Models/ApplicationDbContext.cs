using Microsoft.EntityFrameworkCore;
using TransNeftEnergo.Models;

namespace TransNeftEnergo
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ChildOrganization> ChildOrganizations { get; set; }
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; }
        public DbSet<PowerMeasuringPoint> PowerMeasuringPoints { get; set; }
        public DbSet<PowerSupplyPoint> PowerSupplyPoints { get; set; }
        public DbSet<CurrentMeter> CurrentMeters { get; set; }
        public DbSet<CalculatingMeter> CalculatingMeters { get; set; }
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
        
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local)\SQLEXPRESS;Database=myDataBase;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация связи многие ко многим
            modelBuilder.Entity<PowerMeasuringPointToCalculatingMeter>()
                .HasKey(c => new { c.PowerMeasuringPointId, c.CalculatingMeterId });
            modelBuilder.Entity<PowerMeasuringPointToCalculatingMeter>()
                .HasOne(pc => pc.PowerMeasuringPoint)
                .WithMany(p => p.PowerMeasuringPointToCalculatingMeters)
                .HasForeignKey(pc => pc.PowerMeasuringPointId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PowerMeasuringPointToCalculatingMeter>()
                .HasOne(pc => pc.CalculatingMeter)
                .WithMany(c => c.PowerMeasuringPointToCalculatingMeter)
                .HasForeignKey(pc => pc.CalculatingMeterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<PowerMeasuringPointToCalculatingMeter> PowerMeasuringPointToCalculatingMeter { get; set; }
    }
}
