using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Units
{
    internal interface IUnit
    {
        public int Attack { get; set; }
        public int Defence { get; set; } 
        public int HitPoints { get; set; }

        public void TakeDamage(IUnit opponent);
    }
}
