class Program
{
    public static void Main(string[] args)
    {

        Console.Clear();

        // Welcomes you to my character creation
        Console.WriteLine("Welcome to Character Creation.");
        Console.WriteLine("==============================");
        Console.Write("Type whatever you want to begin: ");
        Console.ReadKey();

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
            Console.Write("Enter your attack value: ");
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

        // *Final notes on this section: This type of input handling works, but is repetative. 
        // *A process like this would benefit from the creation of a standalone method which you will learn later.

        Console.Clear();

        // This will display all inputs made for player creation
        Console.WriteLine("\n ============== Character Profile ============== ");
        Console.WriteLine($"Character's Name: {playerName}");
        Console.WriteLine($"Character's Age: {playerAge}");
        Console.WriteLine($"Character's Favorite Class: {playerFavclass}");
        Console.WriteLine("\n ================ Combat Stats ================= ");
        Console.WriteLine($"Attack: {attack}");
        Console.WriteLine($"Defense: {defense}");
        Console.WriteLine($"Speed: {speed}");

        // Calculate and display power score
        // *Elminated the need to check if 0
        double power = (attack * 2.0 + speed) / defense;
        Console.WriteLine($"\n{playerName}'s Combat Rating is: {power:F2}");

        Console.WriteLine("=============================================");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();

    }
}