// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



Console.WriteLine("Please enter your name for a personalized greeting: ");

string username = "user";
username = Console.ReadLine();

// Console.WriteLine("Welcome to Revature: " + username); // String concatination
// Console.WriteLine("Welcome to Revature: {0}", username); // String interpolation
Console.WriteLine($"Welcome to Revature: {username}"); // String formatting

/*
    Variable Types:
        Decimal
        Int32
        
        Numeric(double, float, long, short, decimal)
        Integer

        Boolean

        char
        string

        byte and bit

    Conditional Statements & Control Flow:
        if, else if, else
        switch, case
        try/catch/finally - exception handling

    Looping:
        for
        do while, while
        for each

*/

bool? runChoice = null;

if( runChoice == true ) 
{
    Console.WriteLine("runChoice is true");
}
else if (runChoice == false )
{
    Console.WriteLine("runChoice is false");
}
else
{
    Console.WriteLine("runChoice is null");
}

/*
    Comparison Operators:
        ==, >, <, >=, <=, !=
*/

