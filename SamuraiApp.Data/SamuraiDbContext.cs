using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.Data
{
    public class SamuraiDbContext:DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SumraiAppData;User ID=sa;password=Allahisthe1; Integrated security=true");
            
        }
        
    }
}
