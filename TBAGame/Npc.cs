using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class Npc
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item DesiredItem { get; set; } = ItemGenerator.None();
        public Item GiftItem { get; set; } = ItemGenerator.None();
        public string DesiredItemDialogue { get; set; }
        public string UndesiredItemDialogue { get; set; } = "Hmmm... That's not what I wanted.";
        public bool Satisfied { get; set; } = false;

        public string[] Dialogue { get; set; } //0: greeting, 1+ "listen" option
        public Npc(string name, string desc, string[] dialogue)
        {
            Name = name;
            Description = desc;
            Dialogue = dialogue;
        }

        public void setDesiredItem(Item desiredItem, string desiredItemDialogue, string undesiredItemDialogue)
        {
            DesiredItem = desiredItem;
            DesiredItemDialogue = desiredItemDialogue;
            UndesiredItemDialogue = undesiredItemDialogue;
        }
        public void setDesiredItem(Item desiredItem, Item giftItem, string desiredItemDialogue, string undesiredItemDialogue)
        {
            DesiredItem = desiredItem;
            GiftItem = giftItem;
            DesiredItemDialogue = desiredItemDialogue;
            UndesiredItemDialogue = undesiredItemDialogue;
        }


    }
}
