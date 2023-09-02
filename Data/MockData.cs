using BissnesLogic.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class MockData
    {
        public static void SeedTransports(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transport>().HasData(new Transport[]
            {
                new Transport()
                {
                    Id = 1,
                    Model = "Test Car",
                    TypeId = (int)TypesC.Standart,
                    Description = "Test standart car",
                    ImagePath = @"https://cdn2.rcstatic.com/images/rc-guides/Economy_Cars/stan.jpg"
                }
            });
        }

        public static void SeedTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Types>().HasData(new Types[]
            {
                new Types() { Id = (int)TypesC.Standart, Name = "Standart", Price = 70 },
                new Types() { Id = (int)TypesC.Ekonom, Name = "Ekonom", Price = 50  },
                new Types() { Id = (int)TypesC.Bisness, Name = "Bisness", Price = 100  },
            });
        }

        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles[]
            {
                new Roles() { Id = TypesD.Full.ToString(), Name = "Administrator" },
                new Roles() { Id = TypesD.Client.ToString(), Name = "Client" },
                new Roles() { Id = TypesD.Partner.ToString(), Name = "Bisness-partner" },
                new Roles() { Id = TypesD.Driver.ToString(), Name = "Driver" },
                new Roles() { Id = TypesD.Corporation.ToString(), Name = "Corporation" },
            });
        }
    }
}
