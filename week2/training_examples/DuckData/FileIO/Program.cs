using System;
using System.IO;
using System.Net;
using DuckData.Repo;
using DuckData.Models;

namespace FileIO
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"./TestText.txt";

            IRepository file = new Serialization();

            // file.ReadAndWriteWithFile( path );

            // Console.WriteLine();
            // file.StreamReaderReadLine( path );
            
            
            // Console.WriteLine();
            // file.StreamReaderReadToEnd( path );

            Duck myDuck = new Duck( "red" , 20 );

            List<Duck> duckList = new List<Duck>();

            // file.SaveDuck( myDuck, path );
            
            duckList.Add( myDuck );
            duckList.Add( new Duck( "green", 100 ) );
            duckList.Add( new Duck( "blue", 104 ) );

            file.SaveAllDucks( duckList, path );



            Console.WriteLine( "\n\n\n" );
            
            // Duck myDuck = new Duck( "purple", 100 );
            // myDuck.Quack();
            // Console.WriteLine(myDuck.ToString());

            path = @"./Ducks.txt";
            // File.WriteAllText( path, myDuck.ToString() );
            // string ducks = File.ReadAllText( path );
            // Console.WriteLine( ducks );
            // string[] duckVals = ducks.Split( " " );
            // foreach (string d in duckVals) Console.WriteLine( d );
            // Duck mySavedDuck = new Duck( duckVals[0], int.Parse( duckVals[1] ) );
            
            // string ducks;
            // string[] duckVals;
            // Duck mySavedDuck;
            
            // List<Duck> duckList = file.ReadDucksFromFile( path );

            

            foreach (Duck d in duckList) d.Quack();

        }

    }

    
}