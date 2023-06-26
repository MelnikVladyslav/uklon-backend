using BissnesLogic.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UklonDbContext : IdentityDbContext
    {
        public UklonDbContext()
        {

        }
        public UklonDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-TF9TNEC;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasOne(p => p.Role)
                                        .WithMany(c => c.Users)
                                        .HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<Transport>().HasOne(p => p.Type)
                                        .WithMany(c => c.Transports)
                                        .HasForeignKey(p => p.TypeId);

            modelBuilder.SeedTransports();
            modelBuilder.SeedRoles();
            modelBuilder.SeedTypes();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
