﻿
using Microsoft.EntityFrameworkCore;
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
            //AddSamuraiWitnQutes();
            //AddQuteWithNoTracked(4);
            //GetSamurais("After Add:");
            ExplictLoadQuery();
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
        private static void JoinBattelandSamurai()
        {
            var sbjoin = new SamuraiBattle { BattleId = 1, SamuraiId = 4 };
            context.Add(sbjoin);
            context.SaveChanges();
        }
        private static void EnlistSamuraiIntoBattel()
        {
            var battle = context.Battles.Find(1);
            battle.SamuraiBattles.Add(new SamuraiBattle { SamuraiId = 7 });
            context.SaveChanges();
        }
        private static void RemovejoinBetweensamuraiAndBattle()
        {
            var join = new SamuraiBattle { BattleId = 1, SamuraiId = 4 };
            context.Remove(join);
            context.SaveChanges();
        }
        private static void GetsamuraiWithBattle()
        {
            var samuraybattle = context.Samurais
                .Include(s => s.SamuraiBattles)
                .ThenInclude(sb => sb.Battle)
                .FirstOrDefault(sam => sam.SamuraiId == 4);

            var samuraibattlecleaner = context.Samurais.Where(s => s.SamuraiId == 4)
                .Select(s => new
                {
                    Samurai = s,
                    Battle = s.SamuraiBattles.Select(sb => sb.Battle)
                }).FirstOrDefault();
        }
        private static void AddNewHorseToSamuraiObject()
        {
            var samurai = context.Samurais.Find(4);
            samurai.Horse = new Horse { HourseName = "Black Beauty" };
            context.SaveChanges();
        }
        private static void AddNewHorseToSamuraiId()
        {
            
            var Horse = new Horse { HourseName = "Black Beauty",SamuraiId=4 };
            context.Add(Horse);
            context.SaveChanges();
        }
        private static void AddNewHorseToDisconectedSamuraiObject()
        {
            var samurai = context.Samurais.AsNoTracking().FirstOrDefault(s => s.SamuraiId == 4);

            samurai.Horse = new Horse { HourseName = "Mr. Eid" };
            using(var newContext=new SamuraiDbContext())
            {
                newContext.Attach(samurai);
                newContext.SaveChanges();
            }
            
        }
        private static void ExplictLoadQuery()
        {
            var samurai = context.Samurais.FirstOrDefault(s => s.SamuraiName.Contains("Mahmoud"));
            context.Entry(samurai).Collection(s => s.Quotes).Load();
            context.Entry(samurai).Reference(s => s.Horse).Load();
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
