using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class TVShopDbContext : DbContext
    {
        //public TvShopDbContext() { }
        public TVShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TV>().HasData(MockData.GetTVs());

            modelBuilder.Entity<Color>().HasData(MockData.GetColors());
        }

        public DbSet<TV> TVs { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
