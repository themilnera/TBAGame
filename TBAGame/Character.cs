using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal abstract class Character
    {
        //name, health, weapon, level
        public string Name { get; set; }
        public string Description { get; set; }
        public int Health { get; set; } = 100;
        public int Level { get; set; }

        public List <Weapon> Weapons { get; set; }
        public Character(string name, string desc, int level, List<Weapon> weapons)
        {
            Name = name;
            Description = desc;
            Level = level;
            Weapons = weapons;
        }
    }
}
