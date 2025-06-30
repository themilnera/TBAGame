using TBAGame;

List<Weapon> playerWeapons = new List<Weapon>();
playerWeapons.Add(new Weapon("Fists", "Use your fists", 1, 5));
playerWeapons.Add(new Weapon("Dagger", "A small sharp knife", 2, 8));
List<Item> playerItems = new List<Item>();
playerItems.Add(new Item("Healing potion", "A small vial of red liquid", true, 2, "health"));

Player player = new Player("PLAYER", "the player", 1, playerWeapons, playerItems);

List<Weapon> monsterWeapons = new List<Weapon>();
monsterWeapons.Add(new Weapon("Claws", "Monster's claws", 1, 2));
monsterWeapons.Add(new Weapon("Teeth", "Sharp teeth", 1, 4));
string[] dialogue = { "I'm gonna eatcha!", "AGH, you've killed me!", "This is pointless!", "Just give up!", "Let me eat you!" };

Monster monster = new Monster("Generic monster", "A generic monster", 1, monsterWeapons, dialogue);

Story story = new Story();
story.CombatEncounter(monster, player);