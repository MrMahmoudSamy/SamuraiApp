using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
   public class Quote
    {
        public int QuoteId { get; set; }
        public string QuotesText { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}
