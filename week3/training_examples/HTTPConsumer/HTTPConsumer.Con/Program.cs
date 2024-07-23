using System;
using System.Net.Http;
using System.Text.Json;
using System.Xml.Serialization;
using HTTPConsumer.Models;

namespace HTTPConsumer.Con
{
    class Program
    {
        public static async Task Main( string[] args )
        {
            // string url = "http://jsonplaceholder.typicode.com/posts/";

            HttpClient client = new HttpClient();

            // string response = await client.GetStringAsync(url);

            // Console.WriteLine(response);

            // List<Post> postList = JsonSerializer.Deserialize<List<Post>>(response);

            // foreach ( var i in postList )
                // Console.WriteLine( $"{i.id} : {i.title}" );


            string baseurl = "https://api.geekdo.com/xmlapi2";
            string searchurl = "/search?exact=1&type=boardgame&query=";
            Console.WriteLine( "search a boardgame: " );
            string search = Console.ReadLine();

            string response = await client.GetStringAsync(baseurl+searchurl+search);

            // Stream response = await client.GetStreamAsync(baseurl+searchurl+search);
            // List<Game> gameList = XmlSerializer.Deserialize<List<Game>>(response);

            Console.WriteLine(response);

            
        }
    }
}