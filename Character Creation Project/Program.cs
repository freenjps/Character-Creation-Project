﻿using System;
using System.IO;

//Module 9 - Adding struct for new enemies
public struct Enemy
{
    public string Name;
    public int HP;
    public int Damage;

    public Enemy(string name, int hp, int damage)
    {
        Name = name;
        HP = hp;
        Damage = damage;
    }
}

//Module 10 - Adding item struct
public struct Item
{
    public string Type;
    public int Value;
    public string Rarity;

    public Item(string type, int value, string rarity)
    {
        Type = type;
        Value = value;
        Rarity = rarity;
    }
}

//Module 11 - Make Character Class
public class Character
{
    public static int CharacterCount = 0;

    public int HP;
    public string ClassType;

    public Character(int hp, string classType)
    {
        HP = hp;
        ClassType = classType;

        // Increment counter when a new character is created
        CharacterCount++;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Class: {ClassType}, HP: {HP}");
    }
}

class Program
{
    // Module 1-11 Main Method that runs as a Main Menu Loop for Gorgus RPG
    public static void Main(string[] args)
    {
        // Module 7 Ability to choose difficulty before Main Menu 
        int gameDifficulty = ChooseDifficulty();
        
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("======= Welcome to Gorgus RPG =======");
            Console.WriteLine($"Current Difficulty: {(gameDifficulty == 1 ? "Easy" : gameDifficulty == 2 ? "Medium" : "Hard")}");
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. Play Dice Game");
            Console.WriteLine("2. Create Character");
            Console.WriteLine("3. Battle Log Tracker");
            Console.WriteLine("4. Save Character Profile to File");
            Console.WriteLine("5. View Enemies");
            Console.WriteLine("6. View Inventory");
            Console.WriteLine("7. Create Character with Counter");
            Console.WriteLine("8. Exit");

            string choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    PlayDiceGame(); break;
                case "2":
                    CreateCharacter(); break;
                case "3":
                    RunBattleLogTracker(); break;
                case "4":
                    CreateClassProfile(); break;
                case "5":
                    ShowEnemies(); break;
                case "6":
                    ShowInventory(); break;
                case "7":
                    CreateCharacterWithCounter(); break;
                case "8":
                    running = false;
                    Console.WriteLine("Thanks for playing Gorgus RPG!");   
                    break;
                default:
                    Console.WriteLine("Invalid input. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Module 10 - added a fixed array of 5 items
    static Item[] inventory = new Item[5]
    {
        new Item("Sword", 150, "Rare"),
        new Item("Potion", 25, "Common"),
        new Item("Shield", 100, "Uncommon"),
        new Item("Gemstone", 500, "Legendary"),
        new Item("Herbs", 15, "Common")
    };

     // Module 7 Difficulty selection method
    public static int ChooseDifficulty()
    {
        int difficulty = 0;
        bool valid = false;

        while (!valid)
        {
            Console.Clear();
            Console.WriteLine("===== Select Game Difficulty =====");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Enter a number (1–3): ");

            try
            {
                string input = Console.ReadLine();
                difficulty = int.Parse(input);

                if (difficulty >= 1 && difficulty <= 3)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose between 1 and 3.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That wasn't a number. Please enter a numeric value.");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }
        }

        return difficulty;
    }

    // Module 5: Dice Game Method
    public static void PlayDiceGame()
    {
        Console.Clear();
        Console.WriteLine(" Dice Rolling Game ");

        bool validChoice = false;

        while (!validChoice)
        {
            Console.Clear();
            Console.WriteLine("\nChoose a die to roll:");
            Console.WriteLine("1. Roll D6 (1–6)");
            Console.WriteLine("2. Roll D20 (1–20)");
            Console.WriteLine("3. Roll Custom Die");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            int result = 0;

            switch (input)
            {
                case "1":
                    result = RollD6();
                    Console.WriteLine($"You rolled a D6 and got: {result}");
                    validChoice = true;
                    break;
                case "2":
                    result = RollD20();
                    Console.WriteLine($"You rolled a D20 and got: {result}");
                    validChoice = true;
                    break;
                case "3":
                    Console.Write("Enter number of sides for custom die: ");
                    string sidesInput = Console.ReadLine();
                    if (int.TryParse(sidesInput, out int sides) && sides > 1)
                    {
                        result = RollCustom(sides);
                        Console.WriteLine($"You rolled a D{sides} and got: {result}");
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of sides. Try again.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;  
            }
        }
    }


    // Method for Dice 6
    public static int RollD6()
    {
        return new Random().Next(1, 7);
    }

    // Method for Dice 20
    public static int RollD20()
    {
        return new Random().Next(1, 21);
    }

    // Method for Custom Dice
    public static int RollCustom(int sides)
    {
        return new Random().Next(1, sides + 1);
    }


    // Module 2-4: Character Creation, Charcter Stats, and Coin Inventory Method
    public static void CreateCharacter()
    {
        Console.Clear();
        Console.Write("Enter your Character's Name: ");
        string? playerName = Console.ReadLine();

        Console.Clear();
        int playerAge;
        Console.Write("Enter your Character's Age: ");
        string stringAge = Console.ReadLine();

        while (!int.TryParse(stringAge, out playerAge))
        {
            Console.WriteLine("Please enter a valid number for your age.");
            stringAge = Console.ReadLine();
        }

        Console.Clear();
        Console.Write("Enter your favorite Character Class: ");
        string? playerFavclass = Console.ReadLine();

        Console.Clear();

        int attack, defense, speed;

        Console.Write("Enter your Attack value: ");
        string attackString = Console.ReadLine();
        while (!int.TryParse(attackString, out attack) || attack <= 0)
        {
            Console.WriteLine("Please enter a valid number for Attack. Must be greater than 0.");
            attackString = Console.ReadLine();
            Console.Clear();
        }

        Console.Write("Enter your Defense value: ");
        string defenseString = Console.ReadLine();
        while (!int.TryParse(defenseString, out defense) || defense <= 0)
        {
            Console.WriteLine("Please enter a valid number for Defense. Must be greater than 0.");
            defenseString = Console.ReadLine();
            Console.Clear();
        }

        Console.Write("Enter your Speed value: ");
        string speedString = Console.ReadLine();
        while (!int.TryParse(speedString, out speed) || speed <= 0)
        {
            Console.WriteLine("Please enter a valid number for Speed. Must be greater than 0.");
            speedString = Console.ReadLine();
            Console.Clear();
        }

        Console.Clear();
        int gold = GetValidatedInput("Enter number of gold coins: ");
        int silver = GetValidatedInput("Enter number of silver coins: ");
        int copper = GetValidatedInput("Enter number of copper coins: ");
        int totalCopper = ConvertToCopper(gold, silver, copper);
        double totalGold = totalCopper / 100.0;

        Console.Clear();
        Console.WriteLine("\n ============== Character Profile ============== ");
        Console.WriteLine($"\nCharacter's Name: {playerName}");
        Console.WriteLine($"Character's Age: {playerAge}");
        Console.WriteLine($"Character's Favorite Class: {playerFavclass}");
        Console.WriteLine("\n ================ Combat Stats ================= ");
        Console.WriteLine($"\nAttack: {attack}");
        Console.WriteLine($"Defense: {defense}");
        Console.WriteLine($"Speed: {speed}");
        double power = (attack * 2.0 + speed) / defense;
        Console.WriteLine($"{playerName}'s Combat Rating is: {power:F2}");
        Console.WriteLine("\n ================= Coin Inventory =============== ");
        Console.WriteLine($"\nGold: {gold}, Silver: {silver}, Copper: {copper}");
        Console.WriteLine($"Total in Copper: {totalCopper}");
        Console.WriteLine($"Total Value in Gold: {totalGold:F2}");
        Console.WriteLine("\n=============================================");
    }

    // Module 4: Valid Coin Input Method
    public static int GetValidatedInput(string prompt)
    {
        int value;
        string input;

        Console.Write(prompt);
        input = Console.ReadLine();

        while (!int.TryParse(input, out value) || value < 0)
        {
            Console.WriteLine("Please enter a valid non-negative number.");
            Console.Write(prompt);
            input = Console.ReadLine();
        }

        return value;
    }

    // Coin conversion method
    public static int ConvertToCopper(int gold, int silver, int copper)
    {
        return gold * 100 + silver * 10 + copper;
    }

    // Module 6: Battle Log Tracker Method
    public static void RunBattleLogTracker()
    {
        Console.Clear();
        Console.WriteLine("======= Battle Log Tracker =======");

        Console.Write("Enter number of turns (up to 10): ");
        int turns;
        while (!int.TryParse(Console.ReadLine(), out turns) || turns <= 0 || turns > 10)
        {
            Console.WriteLine("Please enter a valid number of turns (1–10).");
        }

        int[] damagePerTurn = new int[turns];

        for (int i = 0; i < turns; i++)
        {
            Console.Write($"Enter damage for Turn {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out damagePerTurn[i]) || damagePerTurn[i] < 0)
            {
                Console.WriteLine("Please enter a valid non-negative number.");
            }
        }

        int totalDamage = 0;
        int highestDamage = 0;

        for (int i = 0; i < turns; i++)
        {
            totalDamage += damagePerTurn[i];
            if (damagePerTurn[i] > highestDamage)
            {
                highestDamage = damagePerTurn[i];
            }
        }

            double averageDamage = (double)totalDamage / turns;

            Console.Clear();
            Console.WriteLine("\n--- Combat Summary ---");
            for (int i = 0; i < turns; i++)
            {
                Console.WriteLine($"Turn {i + 1}: {damagePerTurn[i]} DMG");
            }

            Console.WriteLine($"\nTotal Damage: {totalDamage}");
            Console.WriteLine($"Average Damage: {averageDamage:F1}");
            Console.WriteLine($"Highest Damage: {highestDamage}");
    
    }

    // Module 8 Creating and Saving Character Profile
    public static void CreateClassProfile()
    
    {
        Console.Clear();
        Console.WriteLine("===== Create and Save Character Profile =====");

        
        Console.Write("Enter your character's name: ");
        string name = Console.ReadLine();

        
        Console.Write("Enter your class (Warrior, Mage, Assassin): ");
        string charClass = Console.ReadLine();
        string classDescription = "";

        
        switch (charClass.ToLower())
        
        {
            case "warrior":
                classDescription = "A strong melee fighter with high endurance.";
                break;
            case "mage":
                classDescription = "A master of elemental magic and ranged spells.";
                break;
            case "assassin":
                classDescription = "A stealthy assassin who excels at critical hits.";
                break;
            default:
                classDescription = "An adventurer with a mysterious background.";
                break;
        }

        int level;
        Console.Write("Enter your level: ");
        while (!int.TryParse(Console.ReadLine(), out level) || level <= 0)
        
        {
            Console.Write("Please enter a valid positive number for level: ");
        }

        
        string profile = $"Character Name: {name}\nClass: {charClass}\nLevel: {level}\nDescription: {classDescription}";

       
        string fileName = "CharacterProfile.txt";
        File.WriteAllText(fileName, profile);

        Console.WriteLine($"\n Profile saved to '{fileName}'!");
    
    }

    //Module 9 - Public class for enemies
    public static void ShowEnemies()
    {
        Console.Clear();
        Console.WriteLine("===== Enemy Battle Info =====");

        Enemy[] enemies = new Enemy[]
        {
            new Enemy("Orc Warrior", 100, 15),
            new Enemy("Goblin Thief", 60, 10),
            new Enemy("Fire Wyvern", 250, 40)
        };

        foreach (Enemy enemy in enemies)
        {
            Console.WriteLine($"\nEnemy: {enemy.Name}");
            Console.WriteLine($" - HP: {enemy.HP}");
            Console.WriteLine($" - Damage: {enemy.Damage}");
        }

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();

    }
    
    //Module 10 - Method to print inventory
    public static void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine("===== Player Inventory =====");

        for (int i = 0; i < inventory.Length; i++)
        {
                Item item = inventory[i];
                Console.WriteLine($"\nSlot {i + 1}:");
                Console.WriteLine($" - Type: {item.Type}");
                Console.WriteLine($" - Value: {item.Value} gold");
                Console.WriteLine($" - Rarity: {item.Rarity}");
        }

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }

    // Module 11 - Create Character Method
    public static void CreateCharacterWithCounter()
    {
        Console.Clear();
        Console.WriteLine("===== Create a New Character =====");

        Console.Write("Enter class type (e.g., Warrior, Mage): ");
        string classType = Console.ReadLine();

        int hp;
        Console.Write("Enter starting HP: ");
        while (!int.TryParse(Console.ReadLine(), out hp) || hp <= 0)
        {
            Console.Write("Please enter a valid positive number for HP: ");
        }

        // Create the character
        Character newChar = new Character(hp, classType);

        Console.WriteLine("\n !!Character created successfully!!");
        newChar.DisplayInfo();

        Console.WriteLine($"\nTotal characters created: {Character.CharacterCount}");

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }
}


