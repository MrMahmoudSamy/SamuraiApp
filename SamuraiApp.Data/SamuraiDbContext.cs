using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.Data
{
    public class SamuraiDbContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        private static readonly ILoggerFactory ConsoleLoggerFactory =
            LoggerFactory.Create(bulider =>
            {
                bulider
                .AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information)
               .AddConsole();
            });


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SumraiAppData;User ID=sa;password=Allahisthe1; Integrated security=true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
        }
    }
}
