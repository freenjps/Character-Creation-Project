class Program
{
    public static void Main(string[] args)
    {
        // Module 5 New Welcome UI asks for the character creation or dice game
        Console.Clear();
        Console.WriteLine("=======Welcome to Gorgus RPG=======");
        Console.WriteLine("\nPlease choose an option");
        Console.WriteLine("\n1. Play Dice Game");
        Console.WriteLine("2. Create Character");
        Console.Write("\nChoose 1 or 2: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            PlayDiceGame();
            Console.WriteLine("\nPress any key to continue to character creation...");
            Console.ReadKey();
        }

        Console.Clear();

        // This will ask the player's name
        Console.Write("Enter your Character's Name: ");
        string? playerName = Console.ReadLine();
        // The last line should store whatever you put as the player's name as playerName for later

        Console.Clear();

        // This should work as a way to ask for players age and validate it
        int playerAge;
        string stringAge;

        // Uses the while loop to keep prompting for the age until its valid
        Console.Write("Enter your Character's Age: ");
        stringAge = Console.ReadLine();

        while (!int.TryParse(stringAge, out playerAge))
        {
            Console.WriteLine("Please enter a valid number for your age retard.");
            stringAge = Console.ReadLine();
        }

        Console.Clear();

        // This will ask for players favorite class
        Console.Write("Enter your favorite Character Class: ");
        string? playerFavclass = Console.ReadLine();
        // This will store your fav class input

        Console.Clear();

        //Module 3 Add ons: Edited 4/8/2025 by Tom
        // *Main changes are the elimination of the boolean validPower and the addition of the <= 0 condition within the while loops
        // *Overall, the procedure was written well and showed use of boolean, int, and string data types. The alterations I made increase readability and reduce redundancy. 

        // Ask for Combat Stats with validation
        int attack, defense, speed; // *No need to assign zero as these values will be assigned by user later anyways.

        // *Getting input for attack statistic
            Console.Write("Enter your Attack value: ");
            string attackString = Console.ReadLine();
            // *While attackString cannot be parsed into an int OR attack value is less than or equal to 0, the loop prompting will continue.
            // *Note: The order of the conditions in the while parentheses matter. It trys to parse it first, then checks if it is less than zero.
            while (!int.TryParse(attackString, out attack) || attack <= 0)
            {
                Console.WriteLine("Please enter a valid number for Attack. Must be greater than 0.");
                attackString = Console.ReadLine();
                Console.Clear();
            }

        // *Getting input for defense statistic
            Console.Write("Enter your Defense value: ");
            string defenseString = Console.ReadLine();
            while (!int.TryParse(defenseString, out defense) || defense <= 0)
            {
                Console.WriteLine("Please enter a valid number for Defense. Must be greater than 0.");
                defenseString = Console.ReadLine();
                Console.Clear();
            }

        // *Getting input for speed statistic
        Console.Write("Enter your Speed value: ");
            string speedString = Console.ReadLine();
            while (!int.TryParse(speedString, out speed) || speed <= 0)
            {
                Console.WriteLine("Please enter a valid number for Attack. Must be greater than 0.");
                speedString = Console.ReadLine();
                Console.Clear();
            }
        Console.Clear();

       /////// Module 4 Add ons//////
        int gold = GetValidatedInput("Enter number of gold coins: ");
        int silver = GetValidatedInput("Enter number of silver coins: ");
        int copper = GetValidatedInput("Enter number of copper coins: ");

        int totalCopper = ConvertToCopper(gold, silver, copper);
        double totalGold = totalCopper / 100.0;
        
        // *Final notes on this section: This type of input handling works, but is repetative. 
        // *A process like this would benefit from the creation of a standalone method which you will learn later.

        Console.Clear();

        // This will display all inputs made for player creation
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
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();

    }
   
    // Module 4 Made a reusable input method that validates
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

    // Module 4 Made this method to convert all coins to total copper
    public static int ConvertToCopper(int gold, int silver, int copper)
    {
        return gold * 100 + silver * 10 + copper;
    }

    // Module 5 adds methods for the dice roll mini game
    public static int RollD6()
    {
        return new Random().Next(1, 7);
    }

    public static int RollD20()
    {
        return new Random().Next(1, 21);
    }

    public static int RollCustom(int sides)
    {
        return new Random().Next(1, sides + 1);
    }

    // Module 5 This is the method for the actual dice game
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
}