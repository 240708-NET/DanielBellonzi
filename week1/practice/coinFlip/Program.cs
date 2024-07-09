class Program
{
    static void Main( string[] args )
    {
        // Randomly pick a heads or tails
        // Keep track of heads and tails flipped

        // Variables
        int heads = 0;
        int tails = 0;
        int count;
        int flip;
        string countString;

        // Random variable
        Random rand = new Random();


        Console.Write("How Many coin flips should I do? ");
        countString = Console.ReadLine();

        count = Int32.Parse(countString);

        for( int i = 0; i < count; i++ )
        {
            flip = rand.Next(20);
            if( flip % 2 == 0 ) 
            {
                Console.WriteLine($"Coin flip {i+1} was heads");
                heads++;
            }
            else{
                Console.WriteLine($"Coin flip {i+1} was tails");
                tails++;
            }
        }

        Console.WriteLine($"The final count was {heads} heads and {tails} tails");

    }
}