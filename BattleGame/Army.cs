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
        public List<IUnit> units = new List<IUnit>();

        public Army() { }

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
