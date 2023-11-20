using Microsoft.EntityFrameworkCore;
using Marketplace.DataAccessLayer;
using Contracts;

namespace Marketplace.DataAccessLayer
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Auction> Auctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=Marketplace_TestTask");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
                .Property(o => o.Price)
                .HasColumnType("decimal(38,18)");
        }
    }
}