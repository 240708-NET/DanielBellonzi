using System.Runtime.Intrinsics.Arm;
// using budget.Models;

namespace budgetApp
{
    class CLIHandler
    {
        public void addTransaction () 
        {
            int id = 0;
            string tName;
            string tCategory;
            double tValue = 0.10;
            bool credit = false;
            string creditString;
            bool parsed;

            Console.Write ( "Please Enter a name or location for the transaction: " );
            tName = Console.ReadLine();
            Console.Write ( "What category does it fall in? " );
            tCategory = validateCategory();
            do
            {
                Console.Write("(D)ebit or (C)redit?");
                creditString = Console.ReadLine().ToLower();
            }
            while ( creditString[0] != 'c' && creditString[0] != 'd' );
            credit = creditString[0] == 'c' ? true : false;
            Console.Write( "How much was the transaction? " );
            do
            {
                parsed = Double.TryParse(Console.ReadLine(), out tValue);
                if( !parsed )
                {
                    Console.WriteLine("Please enter a number value.");
                }
            }
            while ( !parsed );


            Console.WriteLine( $"Transaction Added: {tCategory}: ({id}) {tName} {(credit ? '-' : '+')}{tValue.ToString("C2")}");
        }

        public void addCategory ()
        {
            string? newCat;

            Console.WriteLine("Please enter new category name or type cancel(c) to cancel:");
            newCat = Console.ReadLine();

            if ( newCat.ToLower() == "Cancel" || newCat.ToLower() == "c" )
            {
                return;
            }
            else if ( !searchCategory( newCat ) )
            {
                Console.WriteLine( $"Category: {newCat} added to database.");
            }
            else
            {
                Console.Clear();
                Console.Write( $"Category {newCat} already exists. " );
                addCategory();
            }
        }

        public void budgetUpdate ()
        {

        }

        // public Category lookupCategory ()
        // {
        //     return new Category();
        // }

        public string lookupCategory ()
        {
            return "";
        }

        public void lookupTransaction ()
        {

        }

        private string validateCategory()
        {
            string searchString = "";
            ConsoleKey k;

            do{
                k = Console.ReadKey().Key;
                if( k == ConsoleKey.Backspace ) searchString = searchString.Substring( 0, searchString.Length - 1);
                else if( k == ConsoleKey.Spacebar ) searchString += " ";
                else if( k != ConsoleKey.Tab && k != ConsoleKey.Enter ) searchString += k;
                
            }
            while( k != ConsoleKey.Enter && k != ConsoleKey.Tab);

            if ( k == ConsoleKey.Tab )
            {
                lookupCategory();
            }

            return searchString;
        }

        private bool searchCategory( string? search )
        {
            return true;
        }

    }
}