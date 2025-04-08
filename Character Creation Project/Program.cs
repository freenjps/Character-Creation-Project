class Program
{
    public static void Main(string[]args)
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
        int playerAge = 0;
        bool validAge = false;

        // Uses the while loop to keep prompting for the age until its valid
        while(!validAge)
        {

            Console.Write("Enter your Character's Age: ");
            string? stringAge = Console.ReadLine();

            // Took this from the web and read some ways to use it, it essentially takes what you input and compares it with the set int to try and convbert it
            if(int.TryParse(stringAge, out playerAge))
            {
               // If it converts it successfully it breaks out of the while loop
               validAge = true;
            }
            else
            {
                // If its unable to convert it, it leavs you in the loop till you enter a valid response
                Console.WriteLine("Please enter a valid number for your age retard.");
            }
        }
     
        Console.Clear();

        // This will ask for players favorite class
        Console.Write("Enter your favorite Character Class: ");
        string? playerFavclass = Console.ReadLine();
        // This will store your fav class input
    
        Console.Clear();
                                                                //Module 3 Add ons
          // Ask for Combat Stats with validation
        int attack = 0, defense = 0, speed = 0;
        bool validPower = false;

        while (!validPower)
        {
            Console.Write("Enter your Attack value: ");
            string? attackInput = Console.ReadLine();
            validPower = int.TryParse(attackInput, out attack);
            if (!validPower) Console.WriteLine("Please enter a valid number for Attack.");
        }

        validPower = false;
        while (!validPower)
        {
            Console.Write("Enter your Defense value: ");
            string? defenseInput = Console.ReadLine();
            validPower = int.TryParse(defenseInput, out defense);
            if (!validPower) Console.WriteLine("Please enter a valid number for Defense.");
        }

        validPower = false;
        while (!validPower)
        {
            Console.Write("Enter your Speed value: ");
            string? speedInput = Console.ReadLine();
            validPower = int.TryParse(speedInput, out speed);
            if (!validPower) Console.WriteLine("Please enter a valid number for Speed.");
        }

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
        if (defense != 0)
        {
            double power = (attack * 2.0 + speed) / defense;
            Console.WriteLine($"\n{playerName}'s Combat Rating is: {power:F2}");
        }
        else
        {
            Console.WriteLine("\nDefense cannot be zero. Cannot calculate Combat Rating.");
        }

        Console.WriteLine("=============================================");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
        
    }
    
}