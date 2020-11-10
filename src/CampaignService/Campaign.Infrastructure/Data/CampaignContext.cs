using System;
using Microsoft.EntityFrameworkCore;
using Campaign.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Campaign.Infrastructure.Data
{
    public class CampaignContext : DbContext
    {
        public CampaignContext(DbContextOptions<CampaignContext> options) : base(options) { }
        
         protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
        
            modelbuilder.UseIdentityAlwaysColumns();
            // modelbuilder.Entity<Campaign>()
            //     .HasOne(e => e.VehicleGroup)
            //     .WithMany(e => e.Campaigns);

            // modelBuilder.Entity<Student>()
            //     .HasOptional(s => s.Address) // Mark Address property optional in Student entity
            //     .WithRequired(ad => ad.Student);
            // modelBuilder.Entity<Vehicle>()
            //     .HasMany<ECU>(s => s.ECUs)
            //     .WithMany(c => c.Vehicles)
            //     .Map(cs =>
            //             {
            //                 cs.MapLeftKey("vehicle_id");
            //                 cs.MapRightKey("ecu_id");
            //                 cs.ToTable("VehicleECU");
            //             });

            
        }
        public DbSet<Campaign.Core.Entities.Campaign> Campaign { get; set; }
         public DbSet<Approver> Approver { get; set; }
         //public DbSet<CampaignDetails> CampaignDetails { get; set; }
         public DbSet<ECU> ECU { get; set; }
         public DbSet<ECUType> ECUType { get; set; }
         public DbSet<Firmware> Firmware { get; set; }
         public DbSet<Vehicle> Vehicle { get; set; }
         public DbSet<VehicleECU> VehicleECU { get; set; }
     public DbSet<VehicleGroup> VehicleGroup { get; set; }
     public DbSet<EmployeeModel> EmployeeModel { get; set; }
     

//         public CampaignContext() { }
//  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
//             optionsBuilder.UseNpgsql("Server=localhost;Port=5433;User Id=postgres;Password=peacock;Database=FOTA;");
              
    }
}