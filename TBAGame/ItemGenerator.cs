using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal static class ItemGenerator
    {
        public static Item None()
        {
            return new Item("none", "none", false, 1, "none");
        }
        public static Item Any()
        {
            return new Item("any", "any", false, 1, "any");
        }
        public static Item HealthPotion(int level)
        {
            return new Item("Health Potion", "A vial of red potion", true, level, "health");
        }
    }
}
