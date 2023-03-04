using BattleGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame
{
    internal class Army
    {
        public string TeamName { get; set; }

        public List<Unit> units = new List<Unit>();

        public int Price {
            get
            {
                int result = 0;

                foreach (var unit in units) 
                {
                    result += unit.Price;
                }

                return result;
            }
        }

        public Army(List<Unit> units, string teamName) 
        {
            this.units = units;
            TeamName = teamName;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            for (int i = 0; i < units.Count; i++)
            {
                sb.Append(units[i].ToString() + '\n');
            }

            return sb.ToString();
        }
    }
}
