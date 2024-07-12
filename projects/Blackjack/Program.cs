using System.Text;

class Program
{
    static void Main( string[] args )
    {
        Console.OutputEncoding = Encoding.UTF8;

        Game newGame = new Game();
        
        string rePlay = "";

        do{
            newGame.PlayGame();
            
            do
            {
                Console.WriteLine("Thank you for playing! Play again? (y/n)");
                rePlay = Console.ReadLine().ToLower();
            } while (rePlay != "y" && rePlay != "n");
            
        } while ( rePlay == "y" );

    }
}