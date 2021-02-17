using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_MPA.Models;

namespace Proiect_MPA.Data
{
    public class MagazinContext: DbContext
    {
        public MagazinContext(DbContextOptions<MagazinContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<GameShop> GameShops { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<GameShop>().ToTable("GameShop");
        }
    }

}
