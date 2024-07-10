class Game 
{
    // Fields
    
    // Variables: 
    int targetNumber;
    private int guessNumber = -1;
    private int roundCount = 0;
    public string guessString { get; set; } = ""; // auto-property

    // Methods
    // getters and setters - short methods that allow you to "get"(retrieve), or "set" (assign) a value to a field

    /*
        public int get_guessNumber()
        {
            return this.guessNumber;
        }

        public void set_guessNumber(int _guessNumber)
        {
            if (_guessNumber > 0)
            {
                this.guessNumber = _guessNumber;
            }
        }
    */

    // Method signature structure
    // [Access Mod] [Modifier] [Return Type] [Method Name] ([Method Parameters])
    /*
        Access Modifiers: public (Anything can access this method/object), private (only accessible from the same object), protected (only accessable from the class/objects or its child/sub/inherited class), internal (can only be accessed from within the same compiled assembly)

        Modifier: the modifier will limit or restrict how a target can be utilized
            readonly: can only be modified in the constructor of the class
            static: this method or field belongs to the Class, not the individual instanceobject
    */

    // Constructor: The method that instantiates an instance of an object

    public Game()
    {
        Random rand = new Random();
        targetNumber = rand.Next(1001);
    }

    public int PlayGame()
    {
        roundCount = 0;
        do 
        {
            // Prompt user to make a guess and store it, iterate round count
            Console.Write("Welcome to High or Low, please pick a number between 0 and 1000 to begin: ");
            guessString = Console.ReadLine();
            roundCount++;

            // Parse user input for guessNumber
            guessNumber = Int32.Parse(guessString);

            // Compare guessNumber to targetNumber
            if (guessNumber == targetNumber)
            {
                Console.WriteLine("You did it, Good job");
            }
            else if(guessNumber > targetNumber)
            {
                Console.WriteLine("Too high, try again: ");
            } 
            else
            {
                Console.WriteLine("Too low, try again: ");
            }
        }
        while (guessNumber != targetNumber);

        return roundCount;

    }
    // Non-access modifiers in programming, specifically in languages like Java and C#, are keywords that provide additional information about the characteristics of a class, method, or variable, without affecting their accessibility.
}