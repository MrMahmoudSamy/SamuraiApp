
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.ConsoleApp
{
    class Program
    {
        private static SamuraiDbContext context = new SamuraiDbContext();
        static void Main(string[] args)
        {
            //context.Database.EnsureCreated();
            //context.Database.EnsureDeleted();
            //GetSamurais("Before Add:");
            AddSamuraiWitnQutes();
            AddQuteWithNoTracked(4);
            //GetSamurais("After Add:");
            Console.Write("Press any key....");
            Console.ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai {SamuraiName="Mahmoud" };
            var samurai2 = new Samurai { SamuraiName = "Samy" };
            context.Samurais.AddRange(samurai,samurai2);
            context.SaveChanges();
        }
        private static void AddSamuraiWitnQutes()
        {
            var samurai = new Samurai
            {
                SamuraiName = "Jakouzi",
                Quotes = new List<Quote>
                {
                   new Quote{QuotesText="Ahmous" }
                }
            };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }
        private static void AddQuteWithNoTracked(int samuraiId)
        {
            var quots = new Quote
            {
                QuotesText = "YeeeHa",
                SamuraiId = samuraiId
            };
            using(var newcontext=new SamuraiDbContext())
            {
                newcontext.Quotes.Add(quots);
                newcontext.SaveChanges();
            }
        }
        private static void GetSamurais(string text)
        {
            var Samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai Count is {Samurais.Count}");
            foreach (var item in Samurais)
            {
                Console.WriteLine(item.SamuraiName);
            }
        }
    }
}
