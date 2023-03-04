using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Units;

namespace BattleGame
{
    internal static class ConsoleDrawer
    {
        private static Dictionary<Type, char> UnitChars = new();

        static ConsoleDrawer() 
        {
            UnitChars.Add(typeof(LightInfantry), '@');
            UnitChars.Add(typeof(HeavyInfantry), '&');
            UnitChars.Add(typeof(Knight), '#');
        }

        public static void DrawBattle(Battle battle)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("___________(Unit-Char pairs)______________________________________________\n");

            foreach (var p in UnitChars)
            {
                Console.WriteLine($"\"{p.Key}\": {p.Value}");
            }

            Console.WriteLine("__________________________________________________________________________\n");

            Console.WriteLine("________________(Armies)__________________________________________________\n");

            Console.WriteLine($"Round: {battle.round}");
            Console.WriteLine($"Turn: {battle.turn}");

            Console.Write($"Army 1 \"{battle.Army1.TeamName}\" with cost {battle.Army1.Price}");

            Console.SetCursorPosition(40, Console.GetCursorPosition().Top);

            Console.Write($"Army 2 \"{battle.Army2.TeamName}\" with cost {battle.Army2.Price}");

            Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 1);

            for (int i = battle.Army1.units.Count - 1; i >= 0; i--)
            {
                Console.Write(UnitChars[battle.Army1.units[i].GetType()]);
                Console.SetCursorPosition(Console.GetCursorPosition().Left-1, Console.GetCursorPosition().Top + 1);
                Console.Write($"HP:{battle.Army1.units[i].HitPoints}");
                Console.SetCursorPosition(Console.GetCursorPosition().Left+2, Console.GetCursorPosition().Top - 1);
            }

            Console.SetCursorPosition(40, Console.GetCursorPosition().Top);

            
            for (int i = 0; i < battle.Army2.units.Count; i++)
            {
                Console.Write(UnitChars[battle.Army2.units[i].GetType()]);
                Console.SetCursorPosition(Console.GetCursorPosition().Left-1, Console.GetCursorPosition().Top + 1);
                Console.Write($"HP:{battle.Army2.units[i].HitPoints}");
                Console.SetCursorPosition(Console.GetCursorPosition().Left+2, Console.GetCursorPosition().Top - 1);
            }

            Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 2);
            Console.WriteLine("__________________________________________________________________________\n");
        }
    }
}
