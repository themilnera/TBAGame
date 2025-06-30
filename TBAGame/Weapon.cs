using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class Weapon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int BaseDamage { get; }
        public Weapon(string name, string desc, int level, int baseDamage) { 
            Name = name;
            Description = desc;
            Level = level; 
            BaseDamage = baseDamage;
        }
    }
}
