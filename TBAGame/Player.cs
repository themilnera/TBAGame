using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class Player : Character
    {
        public List<Item> Items { get; set; }
        public int damageAugmentation { get; set; } = 0;
        public Player(string name, string desc, int level, List<Weapon> weapons, List<Item> items) : base(name, desc, level, weapons)
        {
            Items = items;
        }
    }
}
