using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class MonsterGenerator
    {
        public MonsterGenerator() { 
        
        }
        //Level 1
        public Monster RockCrab()
        {
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(new Weapon("Claw", "The Rock Crab's sharp claw.", 1, 5));
            weapons.Add(new Weapon("Maw", "The Rock Crab's sharp maw.", 1, 7));
            return new Monster("Rock Crab", "It's a gray crab with a hard shell.", 1, weapons, ["Screech!", "NEEEEEE!", "SCRREE!", "SCRAAC!"]);
        }
        public Monster ShoreGoblin()
        {
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(new Weapon("Claw", "The Shore Goblin's claws.", 1, 6));
            weapons.Add(new Weapon("Teeth", "The Shore Goblin's teeth.", 1, 8));
            return new Monster("Shore Goblin", "It's a small goblin with a hungry look.", 1, weapons, ["Eat, eat, eat!", "AHGH WAAA!", "SO hungry!!", "Need flesh!"]);
        }
    }
}
