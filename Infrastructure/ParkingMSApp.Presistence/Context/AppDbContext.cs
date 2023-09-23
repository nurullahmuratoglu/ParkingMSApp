using Microsoft.EntityFrameworkCore;
using ParkingMSApp.Domain.Entities;

namespace ParkingMSApp.Presistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Class1Vehicle> Class1Vehicles { get; set; }
        public DbSet<Class2Vehicle> Class2Vehicles { get; set; }
        public DbSet<Class3Vehicle> Class3Vehicles { get; set; }
        public DbSet<ParkingVehicle> ParkingVehicles { get; set; }
        public DbSet<VehicleWashService> VehicleWashServices { get; set; }
        public DbSet<TireChangeService> TireChangeServices { get; set; }
        public DbSet<FixedFee> FixedFees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasDiscriminator<string>("VehicleClass")
                    .HasValue<Class1Vehicle>("Class1")
                    .HasValue<Class2Vehicle>("Class2")
                    .HasValue<Class3Vehicle>("Class3");


            modelBuilder.Entity<Class1Vehicle>()
                .Property(x => x.Price).HasPrecision(18, 2);

            modelBuilder.Entity<FixedFee>()
                .Property(x => x.HourFee).HasPrecision(18, 2);

            modelBuilder.Entity<ParkingVehicle>()
                .Property(x => x.TotalFee).HasPrecision(18, 2);
            modelBuilder.Entity<ParkingVehicle>()
                .Property(x => x.HourFee).HasPrecision(18, 2);



            modelBuilder.Entity<FixedFee>().HasData(
                new FixedFee { Id = 1, VehicleClass = "Class1", HourFee = 30 },
                new FixedFee { Id = 2, VehicleClass = "Class2", HourFee = 20 },
                new FixedFee { Id = 3, VehicleClass = "Class3", HourFee = 10 });





            base.OnModelCreating(modelBuilder);
        }

    }
}

