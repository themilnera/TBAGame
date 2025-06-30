using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Consumable { get; }
        public int Level { get;  }
        public string Type { get;  }
        public Item(string name, string desc, bool consumable, int level, string type)
        {
            Name = name;
            Description = desc;
            Consumable = consumable;
            Level = level;
            Type = type;
        }
    }
}
