using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class Landmark
    {
        public List<Npc> Npcs { get; set; }
        public string Name;
        public string Description;
        public int CombatChance { get; set; } = 50; //percent
        public List<Item> Items { get; set; }
        public List<Monster> Monsters { get; set; }
        public Landmark(string name, string desc, List<Npc> npcs, List<Monster> monsters, List<Item> items) 
        {
            Name = name;
            Description = desc;
            Npcs = npcs;
            Items = items;
            Monsters = monsters;
        }
    }
}
