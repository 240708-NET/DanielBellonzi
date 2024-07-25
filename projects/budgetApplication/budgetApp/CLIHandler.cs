using System.Data.Common;
using System.Runtime.Intrinsics.Arm;
using budget.Repo;
using budget.Models;
using System.ComponentModel.DataAnnotations;

namespace budgetApp
{
    class CLIHandler
    {
        string connectionstring = File.ReadAllText("./../connectionstring");
        IRepository file = new EFCore();

        public void addTransaction () 
        {
            string tName;
            Category tCategory;
            DateOnly tDate;
            decimal tValue;
            // bool credit = false;
            // string creditString;
            bool parsed;

            Console.WriteLine ( "Please Enter a name or location for the transaction: " );
            tName = Console.ReadLine();

            tCategory = validateCategory();
            // do
            // {
            //     Console.Write("(D)ebit or (C)redit?");
            //     creditString = Console.ReadLine().ToLower();
            // }
            // while ( creditString[0] != 'c' && creditString[0] != 'd' );
            // credit = creditString[0] == 'c' ? true : false;
            Console.WriteLine( "How much was the transaction? " );
            do
            {
                parsed = Decimal.TryParse(Console.ReadLine(), out tValue);
                if( !parsed )
                {
                    Console.WriteLine("Please enter a number value.");
                }
            }
            while ( !parsed );
            Console.WriteLine( "What was the date of the transaction? Please use mm/dd/yyyy ");
            string[] dateArray = Console.ReadLine().Split("/").ToArray();
            int[] dateInt = new int[3];
            for ( int i = 0; i < 3; i++ ) dateInt[i] = Int32.Parse(dateArray[i]);
            tDate = new DateOnly ( dateInt[2], dateInt[0], dateInt[1] );

            file.SaveTransaction( new Transaction( tName, tValue, tDate, tCategory ) );
            Console.WriteLine( $"Transaction Added: {tCategory.CategoryName}: {tName} {tValue:C2}");
        }

        public void addCategory ()
        {
            string? newCat;

            Console.WriteLine("Please enter new category name or type cancel(c) to cancel:");
            newCat = Console.ReadLine();

            if ( newCat.ToLower() == "cancel" || newCat.ToLower() == "c" )
            {
                return;
            }
            else if ( lookupCategory( newCat ) == null )
            {
                file.SaveCategory( new Category( newCat) );
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
            Console.WriteLine( "Total spending by category: " );
            Dictionary<string, decimal> budget = file.GetSpendingByCategory();
            foreach(KeyValuePair<string, decimal> b in budget)
            {
                Console.WriteLine( $"{b.Key}: {b.Value}");
            }
        }

        public List<Category> lookupCategories ( string cName )
        {
            return file.GetCategoriesByName( cName );
        }

        public Category? lookupCategory ( string cName )
        {
            return file.GetCategoryByName( cName );
        }

        public void lookupTransaction ( string startString = "" )
        {
            string searchString = startString;
            ConsoleKey k;
            
            Console.Write ( $"What transaction would you like to look for? \n{startString}" );

            do{
                k = Console.ReadKey().Key;
                if( k == ConsoleKey.Backspace ) searchString = searchString.Substring( 0, searchString.Length - 1);
                else if( k == ConsoleKey.Spacebar ) searchString += " ";
                else if( k != ConsoleKey.Tab && k != ConsoleKey.Enter ) searchString += k;
                
            }
            while( k != ConsoleKey.Enter && k != ConsoleKey.Tab);

            List<Transaction> transactions = file.GetTransactionsByName( searchString );
            if( transactions.Count == 0 )
            {
                Console.WriteLine( "\nNo matching transactions found. Please try again." );
            }
            // else if( categories.Count == 1 )
            // {
            //     Console.Write( $"\r{categories[0].CategoryName}" );
            //     if( Console.ReadKey().Key == ConsoleKey.Enter ) return categories[0];
            //     else return validateCategory( searchString );
            // }
            else
            {
                int index;
                foreach ( Transaction t in transactions ) Console.WriteLine( $"({t.TransactionID}) {t.TransactionName}: {t.TransactionAmount}");
                Console.WriteLine( $"{transactions.Count} options found. Type an ID to edit/delete it, type anything else to return" );
                if( Int32.TryParse( Console.ReadLine(), out index ) )
                {
                    foreach( Transaction t in transactions )
                    {
                        if( t.TransactionID == index ) editTransaction (t);
                    }
                }
            }

        }

        private Category validateCategory( string startString = "" )
        {
            string searchString = startString;
            ConsoleKey k;
            
            Console.Write ( $"What category does it fall in? \n{startString}" );

            do{
                k = Console.ReadKey().Key;
                if( k == ConsoleKey.Backspace ) searchString = searchString.Substring( 0, searchString.Length - 1);
                else if( k == ConsoleKey.Spacebar ) searchString += " ";
                else if( k != ConsoleKey.Tab && k != ConsoleKey.Enter ) searchString += k;
                
            }
            while( k != ConsoleKey.Enter && k != ConsoleKey.Tab);

            if ( k == ConsoleKey.Tab )
            {
                List<Category> categories = lookupCategories( searchString );
                if( categories.Count == 0 )
                {
                    Console.WriteLine( "\nNo matching Category found. Please try again." );
                    return validateCategory();
                }
                else if( categories.Count == 1 )
                {
                    Console.Write( $"\r{categories[0].CategoryName}" );
                    if( Console.ReadKey().Key == ConsoleKey.Enter ) return categories[0];
                    else return validateCategory( searchString );
                }
                else
                {
                    string possibleMatches = "";
                    foreach ( Category c in categories ) possibleMatches += c.CategoryName + ", ";
                    Console.WriteLine( "\nList of possible categories:\n" + possibleMatches.Substring(0, possibleMatches.Length-2) );
                    return validateCategory();
                }
            }
            else 
            {
                Category? category = lookupCategory( searchString );
                if( category == null ) {
                    Console.WriteLine( "\nNo matching Category found. Please try again." );
                    return validateCategory();
                }
                else
                    return category;
            }


        }

        public void editTransaction ( Transaction transaction )
        {
            Console.WriteLine( $"Would you like to edit(e) or delete(d) {transaction.TransactionName}?");
            string input = Console.ReadLine().ToLower();
            if( input == "delete" || input == "d" )
            {
                file.DeleteTransaction( transaction );
            }
            else if( input == "edit" || input == "e" )
            {
                // file.UpdateTransaction( transaction );
            }

        }



    }
}