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
        Army army1;
        Army army2;
        Random rand = new Random();
        int turn = 0;
        int unitPointer = 0;

        public Battle(string json1, string json2) 
        {
            JsonLoader loader = new();
            army1 = loader.LoadArmyFromJson(json1);
            army2 = loader.LoadArmyFromJson(json2);  
        }
        void Turn()
        {
            Army currentArmy;
            Army opposingArmy;

            if (turn % 2 == 0)
            {
                currentArmy = army2;
                opposingArmy = army1;
            }
            else
            {
                currentArmy = army1;
                opposingArmy = army2;
            }

            opposingArmy.units[unitPointer].TakeDamage(currentArmy.units[unitPointer]);
        }
    }
}
