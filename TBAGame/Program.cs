using TBAGame;

ConsoleText text = new ConsoleText();


MonsterGenerator mg = new MonsterGenerator();
List<Monster> beachMonsters = new List<Monster>();
beachMonsters.Add(mg.ShoreGoblin());
beachMonsters.Add(mg.RockCrab());
List<Item> beachItems = new List<Item>();
beachItems.Add(ItemGenerator.HealthPotion(2));
Npc fisherman = new Npc("Fisherman", "A haggard old fisherman with a beard.", ["Ho, ho! Hello there!", "Oh, you don't want to listen to me! I could go on for ages.", "In the old days I was a sailor, I used to have my own ship, you know.", "But now... I just fish on the beach."]);
fisherman.setDesiredItem(ItemGenerator.Any(), "Well, thank you kindly! I always appreciate a gift.", "Oh, that's... Ok then.");
List<Npc> beachNpcs = new List<Npc>();
beachNpcs.Add(fisherman);
Landmark rock = new Landmark("Big rock", "A very large rock", beachNpcs, beachMonsters, beachItems);
List<Landmark> beachLandmarks = new List<Landmark>();
beachLandmarks.Add(rock);
Location beach = new Location("The beach", "A sandy beach", beachLandmarks);


List<Weapon> playerWeapons = new List<Weapon>();
playerWeapons.Add(new Weapon("Fists", "Use your fists", 1, 5));
playerWeapons.Add(new Weapon("Dagger", "A small sharp knife", 5, 8));
List<Item> playerItems = new List<Item>();
playerItems.Add(new Item("Healing potion", "A small vial of red liquid", true, 2, "health"));

Player player = new Player("PLAYER", "the player", 1, playerWeapons, playerItems);

Story story = new Story();
story.ExploreLocation(beach, player);
