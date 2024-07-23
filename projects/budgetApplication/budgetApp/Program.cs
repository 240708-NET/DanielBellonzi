namespace budgetApp
{
    class Program
    {
        public static void Main( string[] args )
        {

            CLIHandler cli = new CLIHandler();

            int option;
            bool parsed;
            bool exit = false;

            do{
                Console.WriteLine( "Welcome to a budget app, what would you like to do? \n(1) Add a transaction\n(2) Add a category\n(3) Budget update\n(4) Look up a category\n(5) Lookup a transaction\n(6) Exit program");
                parsed = Int32.TryParse(Console.ReadLine(), out option);

                if( !parsed )
                {
                    Console.WriteLine("Please enter a number option.");
                }
                else
                {
                    switch( option )
                    {
                        case 1:
                            Console.Clear();
                            cli.addTransaction();
                            break;
                        case 2:
                            Console.Clear();
                            cli.addCategory();
                            break;
                        case 3:
                            Console.Clear();
                            cli.budgetUpdate();
                            break;
                        case 4:
                            Console.Clear();
                            cli.lookupCategory();
                            break;
                        case 5:
                            Console.Clear();
                            cli.lookupTransaction();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Thank you for using *Budget App*");
                            exit = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a valid menu option.");
                            break;

                    }
                }

            }
            while( !exit );
        }

    }
}