using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Units
{
    internal interface ISpecialAbility
    {
        public int SpecialAbilityStrength { get; set; }
        public int SpecialAbilityRange { get; set; }
    }
}
