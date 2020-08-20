using FitKitApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.Data
{
    public class FitKitAppContext: IdentityDbContext<AppUser>
    {
        public FitKitAppContext(DbContextOptions<FitKitAppContext> options)
            : base(options) { }


        public DbSet<Coach> Coach { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Objekt> Objekt { get; set; }

        public DbSet<Zaclenuvanje> Zaclenuvanje { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Objekt>()
               .HasOne<Coach>(p => p.Coach1)
               .WithMany(p => p.Objekti1)
               .HasForeignKey(p => p.Coach1Id);

            builder.Entity<Objekt>()
                .HasOne<Coach>(s => s.Coach2)
                .WithMany(s => s.Objekti2)
                .HasForeignKey(s => s.Coach2Id);

            builder.Entity<Zaclenuvanje>()
               .HasOne<Objekt>(o => o.Objekt)
               .WithMany(o => o.Korisnici)
               .HasForeignKey(o => o.ObjektId);

            builder.Entity<Zaclenuvanje>()
                .HasOne<User>(u => u.User)
                .WithMany(u => u.Objekti)
                .HasForeignKey(u => u.UserId);
     

        }

        
    }
}
