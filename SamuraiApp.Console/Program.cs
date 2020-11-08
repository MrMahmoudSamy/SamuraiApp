using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SamuraiApp.ConsoleApp
{
    class Program
    {
        private static SamuraiDbContext context = new SamuraiDbContext();
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            AddSamurai();
            GetSamurais("After Add:");
            Console.Write("Press any key....");
            Console.ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai {SamuraiName="Mahmoud" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
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
