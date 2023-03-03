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

        JsonLoader loader = new();

        var army1 = loader.LoadArmyFromJson(json_text1);
        var army2 = loader.LoadArmyFromJson(json_text1);

        Console.WriteLine(army1);
        Console.WriteLine(army2);
    }
}