using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Units
{
    internal abstract class Unit : IUnit
    {
        public virtual int Attack { get; set; }
        public virtual int Defence { get; set; }
        public virtual int HitPoints { get; set; }

        protected Unit()
        { 
        
        }
        protected Unit(int attack, int defence, int hitPoints)
        {
            Attack = attack;
            Defence = defence;
            HitPoints = hitPoints;
        }
        public virtual void TakeDamage(IUnit opponent)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "{" + $"Attack = {Attack}, Defence = {Defence}, HitPoint = {HitPoints}" + "}";
        }
    }
}
