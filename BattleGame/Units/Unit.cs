﻿using System;
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
        private int _hitPoints;
        public virtual int HitPoints {
            get { return _hitPoints; }
            set 
            {
                _hitPoints = Math.Max(value, 0);
            }
        }
        public int Price { 
            get 
            {
                int result = Attack + Defence + HitPoints; 

                if (this is ISpecialAbility)
                {
                    result += ((ISpecialAbility)this).SpecialAbilityRange;
                    result += ((ISpecialAbility)this).SpecialAbilityStrength;
                }

                return result;
            } 
        }

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
            HitPoints -= opponent.Attack;
        }

        public override string ToString()
        {
            return "{" + $"Attack = {Attack}, Defence = {Defence}, HitPoint = {HitPoints}" + "}";
        }
    }
}
