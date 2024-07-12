// play FizzBuzz
// As a user, I want to Play Fizz Buzz from 1 to 20
// count from lower to upper numbers, printing each on it's own line
// When a multiple of 3 is being printed, replace it with fizz
// When a multiple of 5, replace it with buzz
// When it's a multiple of both, print fizzbuzz
// When a multiple of 7 replace it with bang
// When a multiple of 3 and 7, print fizzbang
// When a multiple of 5 and 7, print buzzbang
// When a multiple of 3, 5 and 7, print fizzbuzzbang
// When a multiple of 9, print crack


class Program
{
    static void Main( string[] args)
    {
        int lowerLimit = 1;
        int upperLimit = 20;

        if ( args.Length > 0) {
            try{
                upperLimit = Int32.Parse(args[0]);
            }
            catch ( FormatException )
            {
                Console.WriteLine("Not a valid value, will default to 20");
            }
        }

        // int fizzNum = 3;
        // int buzzNum = 5;
        // int bangNum = 7;
        // int crackNum = 9;

        Dictionary<int, string> wordVals = new Dictionary<int, string>();
        wordVals.Add( 3 , "fizz" );
        wordVals.Add( 5 , "buzz" );
        wordVals.Add( 7 , "bang" );
        wordVals.Add( 9 , "crack" );

        int count;
        for ( int i = lowerLimit; i <= upperLimit; i++ )
        {
            count = 0;

            // if ( i % fizzNum == 0 ) 
            // {
            //     Console.Write( "fizz" );
            //     count++;
            // }
            // if ( i % buzzNum == 0 )
            // {
            //     Console.Write( "buzz" );
            //     count++;
            // }
            // if ( i % bangNum == 0 )
            // {
            //     Console.Write( "bang" );
            //     count++;
            // }
            // if ( i % crackNum == 0 )
            // {
            //     Console.Write( "crack" );
            //     count++;
            // }
            foreach ( KeyValuePair<int, string> val in wordVals)
            {
                if (i % val.Key == 0)
                {
                    Console.Write(val.Value);
                    count++;
                }
            }

            if ( count == 0 ) Console.Write( i );
            
            Console.WriteLine();

        }
    }
}