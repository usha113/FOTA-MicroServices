using System;
using Microsoft.EntityFrameworkCore;
using User.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace User.Infrastructure.Data
{
    public class UserProfileContext : DbContext
    {
        public UserProfileContext(DbContextOptions options) : base(options) { }
         protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
        
            modelbuilder.UseIdentityAlwaysColumns();
            modelbuilder.Entity<UserProfile>()
                .HasOne(e => e.Role)
                .WithMany(e => e.UserProfiles);
        }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<DeviceToken> Token { get; set; }

        public UserProfileContext() { }
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Server=localhost;Port=5433;User Id=postgres;Password=peacock;Database=FOTA;");
              
    }
}