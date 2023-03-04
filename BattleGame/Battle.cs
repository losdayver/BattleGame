using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Units;

namespace BattleGame
{
    internal class Battle
    {
        public Army Army1 { get; set; }
        public Army Army2 { get; set; }
        Random rand = new Random();
        public int turn = 0;
        public int round = 0;
        int unitPointer = 0;

        public Battle(string json1, string json2) 
        {
            JsonLoader loader = new();
            Army1 = loader.LoadArmyFromJson(json1);
            Army2 = loader.LoadArmyFromJson(json2);  
        }
        public void MakeTurn()
        {
            Army currentArmy;
            Army opposingArmy;

            if (turn % 2 == 0)
            {
                currentArmy = Army2;
                opposingArmy = Army1;
            }
            else
            {
                currentArmy = Army1;
                opposingArmy = Army2;
            }

            opposingArmy.units[0].TakeDamage(currentArmy.units[0]);
            if (opposingArmy.units[0].HitPoints > 0)
                currentArmy.units[0].TakeDamage(opposingArmy.units[0]);
            else
            {
                turn++;
                opposingArmy.units.RemoveAt(0);
                return;
            }

            turn++;
        }
    }
}
