using System;
class Program
{
    // Module 1-6 Main Method that runs as a Main Menu Loop for Gorgus RPG
    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("======= Welcome to Gorgus RPG =======");
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. Play Dice Game");
            Console.WriteLine("2. Create Character");
            Console.WriteLine("3. Battle Log Tracker");
            Console.WriteLine("4. Exit");
            Console.Write("\nChoose 1, 2, 3, or 4: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayDiceGame();
                    Console.WriteLine("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    break;

                case "2":
                    CreateCharacter();
                    Console.WriteLine("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    break;

                case "3":
                    RunBattleLogTracker();
                    Console.WriteLine("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    break;

                case "4":
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

    // Module 5: Dice Game Method
    public static void PlayDiceGame()
    {
        Console.Clear();
        Console.WriteLine("🎲 Dice Rolling Game 🎲");

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
}

