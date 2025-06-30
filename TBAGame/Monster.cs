using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class Monster : Character
    {
        public string[] CombatDialogue { get; set; } //0: initial dialogue, 1: death dialogue, 2+ midfight dialogue
        public Monster(string name, string desc, int level, List<Weapon> weapons, string[] combatDialogue) : base(name, desc, level, weapons)
        {
            CombatDialogue = combatDialogue;
        }

        public string getCombatDialogue(int index)
        {
            switch (index)
            {
                case 0:
                    return CombatDialogue[0];
                case 1:
                    return CombatDialogue[1];
                case 2:
                    return CombatDialogue[2];
                case 3:
                    return CombatDialogue[3];
                case 4:
                    return CombatDialogue[4];
                default:
                    return "Failed to get combat dialogue";
            }
        }
    }
}
