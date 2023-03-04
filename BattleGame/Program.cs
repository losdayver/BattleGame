using System.Text.Json;
using System.Text.Json.Nodes;
using BattleGame;
using Newtonsoft.Json;


class Program
{
    static void Main()
    {
        string json_text1 = File.ReadAllText("..\\..\\..\\army1.json");
        string json_text2 = File.ReadAllText("..\\..\\..\\army2.json");

        Battle battle = new(json_text1, json_text2);

        while (true)
        {
            ConsoleDrawer.DrawBattle(battle);
            Console.ReadKey();
            battle.MakeTurn();
        }

        //Console.WriteLine(battle.Army1);
        //Console.WriteLine(battle.Army2);
    }
}