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
        Boolean inCombat = false;
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
                    text.AddLine($"For a total of {total} damage!");
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
                int extraHitChance = rand.Next(1, 101);
                if (extraHitChance < levelTotal)
                {
                    extraHits++;
                }
            }
            return extraHits;
        }
    }
}
