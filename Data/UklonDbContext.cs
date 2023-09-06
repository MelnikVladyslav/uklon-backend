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

            optionsBuilder.UseNpgsql(@"Server=10.8.0.1:5432;Database=uklondb;User ID=uklonuser;Password=$522*6$resdOidjervadbBffii**oouRddkLLkd::dGss99&GDedjjdsLLus3$$)K$t!Ube22}xk");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasOne(p => p.Role)
                                        .WithMany(c => c.Users)
                                        .HasForeignKey(p => p.RoleId)
                                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transport>().HasOne(p => p.Type)
                                        .WithMany(c => c.Transports)
                                        .HasForeignKey(p => p.TypeId)
                                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.SeedTransports();
            modelBuilder.SeedRoles();
            modelBuilder.SeedTypes();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<News> News { get; set; }
    }
}
