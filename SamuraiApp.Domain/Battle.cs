﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
   public class Battle
    {
        public Battle()
        {
            SamuraiBattles = new List<SamuraiBattle>();
        }
        public int BattleId { get; set; }
        public string BattleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
    }
}