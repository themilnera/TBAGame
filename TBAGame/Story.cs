using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class Story
    {
        //functions for generating story options
        ConsoleText text = new ConsoleText();
        Random rand = new Random();
        bool inCombat = false;
        bool exploringLocation = false;
        bool talkingToNpc = false;
        bool visitingLandmark = false;
        public void ExploreLocation(Location location, Player player)
        {
            exploringLocation = true;
            while (exploringLocation)
            {
                text.CleanLine("You arrive at: " + location.Name);
                text.AddLine(location.Description);
                text.GetLine();
                text.CleanLine("You can visit these landmarks:");
                int i;
                for (i = 0; i < location.Landmarks.Count; i++)
                {
                    text.AddLine($"{i + 1}) {location.Landmarks[i].Name}");
                }
                text.AddLine($"{i + 1}) Move on to next location");
                int choice = text.GetLineInt(location.Landmarks.Count + 1) - 1;
                if (choice < location.Landmarks.Count)
                {
                    VisitLandmark(location, player, location.Landmarks[choice]);
                }
                else
                {
                    text.AddLine("Moving to next location...");
                    exploringLocation = false;
                    break;
                }
            }
        }

        public void TalkToNpc(Location location, Player player, Landmark landmark, Npc npc)
        {
            talkingToNpc = true;
            while (talkingToNpc)
            {
                text.CleanLine("talking to: " + npc.Name);
                text.AddLine($"{npc.Dialogue[0]}");
                text.AddLine("1) Listen");
                text.AddLine("2) Give item");
                text.AddLine("3) Exit conversation");
                int choice = text.GetLineInt(3);
                if (choice == 1)
                {
                    for (int i = 1; i < npc.Dialogue.Count(); i++)
                    {
                        text.CleanLine(npc.Dialogue[i]);
                        text.GetLine();
                    }
                }
                if (choice == 2)
                {
                    if (player.Items.Count > 0)
                    {
                        int j;
                        for (j = 0; j < player.Items.Count; j++)
                        {
                            text.AddLine($"{j + 1}) {player.Items[j].Name}");
                        }
                        text.AddLine($"{j + 1}) I changed my mind");
                        int itemChoice = text.GetLineInt(player.Items.Count + 1);
                        if (itemChoice <= player.Items.Count)
                        {
                            text.AddLine($"You give item: {player.Items[itemChoice - 1].Name} to {npc.Name}");
                            text.GetLine();
                            if (player.Items[itemChoice - 1].Name == npc.DesiredItem.Name || npc.DesiredItem.Name == "any")
                            {
                                text.AddLine(npc.DesiredItemDialogue);
                            }
                            else
                            {
                                text.AddLine(npc.UndesiredItemDialogue);
                            }
                            text.GetLine();
                        }
                    }
                    else
                    {
                        text.CleanLine("You don't have any items");
                    }
                }
                if (choice == 3)
                {
                    talkingToNpc = false;
                    break;
                }
            }
        }
            
        
        public void VisitLandmark(Location location, Player player, Landmark landmark)
        {
            visitingLandmark = true;
            while (visitingLandmark)
            {
                text.CleanLine("Visiting landmark: " + landmark.Name);
                text.AddLine("Description: " + landmark.Description);
                text.GetLine();
                int combatChance = rand.Next(1, 101);
                if (combatChance < landmark.CombatChance)
                {
                    int ei = rand.Next(0, landmark.Monsters.Count);
                    CombatEncounter(landmark.Monsters[ei], player);
                    text.CleanLine("Visiting landmark: " + landmark.Name);
                    text.AddLine("Description: " + landmark.Description);
                }

                if (landmark.Npcs.Count > 0)
                {
                    text.AddLine("You can talk to: ");
                    int i;
                    for (i = 0; i < landmark.Npcs.Count; i++)
                    {
                        text.AddLine($"{i + 1}) {landmark.Npcs[i].Name}");
                    }
                    text.AddLine($"{i + 1}) Search for items instead");
                    text.AddLine($"{i + 2}) Leave landmark");
                    int choice = text.GetLineInt(landmark.Npcs.Count + 2);
                    if (choice <= landmark.Npcs.Count)
                    {
                        TalkToNpc(location, player, landmark, landmark.Npcs[choice - 1]);
                    }
                    else if (choice == landmark.Npcs.Count + 1)
                    {
                        if (landmark.Items.Count > 0)
                        {
                            text.AddLine("You found items: ");
                            for (int j = 0; j < landmark.Items.Count; j++)
                            {
                                text.AddLine(landmark.Items[j].Name);
                                player.Items.Add(landmark.Items[j]);
                                landmark.Items.RemoveAt(j);
                            }
                        }
                        else
                        {
                            text.AddLine("No items found.");
                        }
                    }
                    else
                    {
                        visitingLandmark = false;
                        break;
                    }

                }
                else
                {
                    text.AddLine("You found items: ");
                    for (int i = 0; i < landmark.Items.Count; i++)
                    {
                        text.AddLine(landmark.Items[i].Name);
                        player.Items.Add(landmark.Items[i]);
                    }
                }
                text.GetLine();
            }
        }
        public void PlayerTurn(Monster monster, Player player)
        {
            text.CleanLine("It's your turn! Choose an option:");
            text.AddLine("1) Attack with equipped weapon");
            text.AddLine("2) Use item");
            text.AddLine("3) Attempt to flee");
            int choice = text.GetLineInt(3);
            switch (choice)
            {
                case 1:
                    text.CleanLine("Weapons:");
                    for (int i = 0; i < player.Weapons.Count; i++)
                    {
                        text.AddLine($"{i+1}) Level {player.Weapons[i].Level} {player.Weapons[i].Name}");
                    }
                    int choice2 = text.GetLineInt(player.Weapons.Count)-1;
                    text.CleanLine($"Attacking with {player.Weapons[choice2].Name}");
                    int prevMonsterHealth = monster.Health;
                    monster.Health -= player.Weapons[choice2].BaseDamage;
                    int levelTotal = player.Weapons[choice2].Level + player.Level;
                    int extra = CalculateExtraHits(levelTotal) * player.Weapons[choice2].BaseDamage;
                    monster.Health -= extra;
                    int total = player.Weapons[choice2].BaseDamage + extra;
                    text.AddLine($"For a total of {total} damage! ({player.Weapons[choice2].BaseDamage} + {extra})");
                    text.AddLine($"The {monster.Name}'s health: {prevMonsterHealth} -> {monster.Health}");
                    break;
                case 2:
                    text.CleanLine("Items:");
                    if (player.Items.Count > 0)
                    {
                        for (int i = 0; i < player.Items.Count; i++)
                        {
                            text.AddLine($"{i+1}) {player.Items[i].Name}");
                        }
                        int choice3 = text.GetLineInt(player.Items.Count)-1;
                        text.CleanLine("Using item: " + player.Items[choice3].Name);
                        if (player.Items[choice3].Type == "health")
                        {
                            int healingAmt = player.Items[choice3].Level * 10;
                            player.Health += healingAmt;
                            text.AddLine($"Healed {player.Name} for {healingAmt} points!");
                        }
                        if (player.Items[choice3].Type == "damage")
                        {
                            player.damageAugmentation = player.Items[choice3].Level;
                        }
                    }
                    else
                    {
                        text.AddLine("No items");
                        text.GetLine();
                        PlayerTurn(monster, player);
                    }
                        break;
                case 3:
                    text.CleanLine("You attempt to flee combat");
                    text.GetLine();
                    int chance = rand.Next(1, 101);
                    int threshold;
                    if (monster.Level > player.Level)
                    {
                        threshold = monster.Level - player.Level;
                    }
                    else
                    {
                        threshold = 0;
                    }
                    if(threshold == 0)
                    {
                        text.AddLine("You flee successfully!");
                        inCombat = false;
                    }
                    else
                    {
                        if (chance > threshold * 10)
                        {
                            text.AddLine("You flee successfully!");
                            inCombat = false;
                        }
                        else
                        {
                            text.AddLine("You failed to flee");
                        }
                    }
                    break;
            }
            text.GetLine();
        }
        public void MonsterTurn(Monster monster, Player player)
        {
            text.CleanLine($"It's the {monster.Name}'s turn!");
            text.AddLine($"{monster.Name}: \"{monster.CombatDialogue[rand.Next(2, monster.CombatDialogue.Length)]}\"");
            text.GetLine();
            Weapon weaponChoice = monster.Weapons[rand.Next(0, monster.Weapons.Count)];
            int extraHits = CalculateExtraHits(monster.Level + weaponChoice.Level);
            int totalDamage = weaponChoice.BaseDamage;
            if(extraHits > 0)
            {
                totalDamage *= extraHits;
            }
            text.AddLine($"{monster.Name} attacks with {weaponChoice.Name} for {totalDamage} damage!");
            int prevHealth = player.Health;
            player.Health -= totalDamage;
            text.AddLine($"{player.Name}'s Health: {prevHealth} -> {player.Health}");
            text.GetLine();
        }
        public void CombatEncounter(Monster monster, Player player)
        {
            inCombat = true;
            text.CleanLine($"You enter combat with a level {monster.Level} {monster.Name}!", ConsoleColor.Green);
            text.GetLine();
            text.CleanLine($"{monster.Name}: \"{monster.getCombatDialogue(0)}\"");
            text.AddLine($"Monster's Health: " + monster.Health);
            while(inCombat)
            {
                PlayerTurn(monster, player);
                if (!inCombat)
                {
                    break;
                }
                if(monster.Health <= 0)
                {
                    text.AddLine($"{monster.Name}: \"{monster.CombatDialogue[1]}\"");
                    text.CleanLine("You won!", ConsoleColor.Green);
                    inCombat = false;
                    break;
                }
                MonsterTurn(monster, player);
            }
        }

        private int CalculateExtraHits(int levelTotal)
        {
            
            int extraHits = 0;

            for(int i = 0; i < levelTotal; i++)
            {
                int extraHitChance = rand.Next(1, 26);
                if (extraHitChance < levelTotal)
                {
                    extraHits++;
                }
            }
            return extraHits;
        }
    }
}
