using BattleGame.Units;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame
{ 

    internal class JsonLoader
    {
        public Army LoadArmyFromJson(string jsonText)
        {
            army_json jarmy = JsonConvert.DeserializeObject<army_json>(jsonText);

            List<Unit> units = new List<Unit>();

            for (int i = 0; i < jarmy.units.Length; i++)
            {
                // TODO добавить возможность нелинейной адресации юнитов (по полю UnitDescriptionId)
                var junit = jarmy.UnitDescriptions[jarmy.units[i] - 1];
                var unit = ConvertJsonUnit(junit);

                units.Add(unit);
            }

            var army = new Army(units, jarmy.TeamName);

            if (army.Price > 100)
                throw new Exception("Превышена цена армии " + army.TeamName + ": " + army.Price);

            return army;

            Unit ConvertJsonUnit(unit_json junit)
            {
                Unit unit;

                switch (junit.UnitName)
                {
                    case "Light Infantry":
                        unit = new LightInfantry(junit.Attack, junit.Defence, junit.HitPoints);
                        break;
                    case "Heavy Infantry":
                        unit = new HeavyInfantry(junit.Attack, junit.Defence, junit.HitPoints);
                        break;
                    case "Knight":
                        unit = new Knight(junit.Attack, junit.Defence, junit.HitPoints);
                        break;
                    default:
                        throw new Exception("Юнит не существует");
                }

                return unit;
            }
        }
    }

    file class army_json
    {
        public string TeamName;
        public unit_json[] UnitDescriptions;
        public int[] units;
    }

    file class unit_json
    {
        public int UnitDescriptionId;
        public string UnitName;
        public int Attack;
        public int Defence;
        public int HitPoints;
    }
}
