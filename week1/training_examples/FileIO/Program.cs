using System;

namespace FileIO
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"./TestText.txt";

            string text = "some sample text for the file";

            // read, write (overwrite), append (add to end of file)
            if( !File.Exists( path ))
            {
                File.WriteAllText( path, text );
            }
            else
            {
                File.ReadAllText ( path );
            }
            
        }
    }
}