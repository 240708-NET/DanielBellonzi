using DuckData.Models;

namespace DuckData.Repo
{
    public class FileReadWrite : IRepository
    {
        public void ReadAndWriteWithFile ( string path )
        {
            string text = "some sample text for the file";
            // read, write (overwrite), append (add to end of file)
            if( !File.Exists ( path ))
            {
                File.WriteAllText ( path, text );
            }
            else
            {
                Console.WriteLine( "Reading from file with File.ReadAllText: " );
                text = File.ReadAllText ( path );
                Console.WriteLine( text );
                
            }
        }

        public void StreamReaderReadLine( string path )
        {
            string text = "some sample text for the file";
            /*
                StreamReader doesn't load the file, it provides a route to the file.
                rather than  retrieving the entire file to memory, we can read each line one at a time, reducing the memory required.
            */
            StreamReader? sr = new StreamReader( path );
            Console.WriteLine ( "Reading from file with streamreader" );
            while ( (text = sr.ReadLine()) != null )
            {
                Console.WriteLine ( text );
                Console.WriteLine ( " --- ");
            }

            sr.Close();
            sr = new StreamReader ( path );
        }

        public void StreamReaderReadToEnd( string path )
        {
            string text = "some sample text for the file";
            StreamReader? sr = new StreamReader( path );
            Console.WriteLine( "Reading from file with streamreader (EOF): " );
            while ( (text = sr.ReadToEnd()) != "" )
            {
                Console.Write ( text );
                Console.WriteLine ( " --- " );
            }
        }

        public List<Duck> ReadDucksFromFile( string path )
        {
            StreamReader? sr = new StreamReader( path );
            List<Duck> duckList = new List<Duck>();
            string duck;

            while ( (duck = sr.ReadLine()) != null )
            {
                string[] duckVals = duck.Split( " " );
                Duck mySavedDuck = new Duck( duckVals[0], int.Parse( duckVals[1] ) );
                duckList.Add( mySavedDuck );
            }

            return duckList;
        }

        public void SaveDuck( Duck duck, string path ){}
    }
}