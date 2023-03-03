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

            List<IUnit> units = new List<IUnit>();

            for (int i = 0; i < jarmy.units.Length; i++)
            {
                // TODO добавить возможность нелинейной адресации юнитов (по полю UnitDescriptionId)
                var junit = jarmy.UnitDescriptions[jarmy.units[i] - 1];
                var unit = ConvertJsonUnit(junit);

                units.Add(unit);
            }

            var army = new Army();

            army.units = units;

            IUnit ConvertJsonUnit(unit_json junit)
            {
                IUnit unit;

                switch (junit.UnitName)
                {
                    case "Light Infantry":
                        unit = new LightInfantry();
                        break;
                    case "Heavy Infantry":
                        unit = new HeavyInfantry();
                        break;
                    case "Knight":
                        unit = new Knight();
                        break;
                    default:
                        throw new Exception("Юнит не существует");
                }

                unit.Attack = junit.Attack;
                unit.Defence = junit.Defence;
                unit.HitPoints = junit.HitPoints;

                return unit;
            }

            return army;
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
