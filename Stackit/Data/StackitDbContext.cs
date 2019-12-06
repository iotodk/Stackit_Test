using Microsoft.EntityFrameworkCore;
using Stackit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackit.Data
{
    public class StackitDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }

        public StackitDbContext(DbContextOptions<StackitDbContext> options) :  base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientType>().HasData(
                new ClientType { Id = 1, Name = "S_Admin" },
                new ClientType { Id = 2, Name = "S_Operator" },
                new ClientType { Id = 3, Name = "K_Admin" },
                new ClientType { Id = 4, Name = "K_Ope" }
            );
        }
    }
}
