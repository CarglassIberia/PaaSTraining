namespace BuyCoffee.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public class WhoBuyedCoffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset When { get; set; }
        public decimal Cost { get; set; }
    }

    public class CoffeeBuyersContext : DbContext
    {

        public CoffeeBuyersContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<WhoBuyedCoffee> CoffeeBuyers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}