using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
   public class Samurai
    {
        public Samurai()
        {
            Quotes = new List<Quote>();
            SamuraiBattles = new List<SamuraiBattle>();
        }
        public int SamuraiId { get; set; }
        public string SamuraiName { get; set; }
        public Clan Clan { get; set; }
        public List<Quote> Quotes { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
    }
}
