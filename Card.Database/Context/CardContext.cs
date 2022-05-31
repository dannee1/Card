using Card.Database.Mappgings;
using Card.Domain.Entities;
using Card.Domain.Entities.CardAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Card.Database.Context
{
    public class CardContext : DbContext
    {
        public DbSet<CustomerCard> Cards { get; set; }


        public CardContext(DbContextOptions<CardContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardMapping());
         

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), o => o.UseRowNumberForPaging());
            }


        }
    }
}
