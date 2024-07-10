class Program
{

    // Fields

    // Methods 


    static void Main( string[] args )
    {
        /*
            In Software Development Life Cycle (SDLC) a user story is a way to track a feature
        */
        // computer should pick a random number
        // prompt user to guess numbeR
        // if the guess is higher or lower than target number, couputer should say so
        // user should keep guessing until they guess the correct number
        // user wins when correct number is guessed

        // Singleton - A single instance of a thing that is referenced throughout the application to complete some functionality
        // Create an Instance of the Game Class

        /*  Now in the Game class

            // Variables: 
            int targetNumber;
            int guessNumber;
            int roundCount;
            string guessString;

            // Create a random number
            Random rand = new Random();
            targetNumber = rand.Next(1001);
            roundCount = 0;


            do {
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
        */

        Game newGame = new Game();
        
        int roundCount = newGame.PlayGame();

        Console.WriteLine($"You guessed it in {roundCount} rounds!Thanks for playing!");

    }
}