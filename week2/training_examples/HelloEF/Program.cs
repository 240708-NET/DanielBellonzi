using System;
using Microsoft.EntityFrameworkCore;

namespace HelloEF
{
    class Program
    {
        public static void Main( string[] args )
        {
            // Console.WriteLine( "Hello Again! ");

            Pet MyPet = new Pet{ Name = "Sil", Cuteness = 9, Chaos = 100, Species = "Cat" };
            Console.WriteLine( MyPet.Speak() );

            // Data Context ??
            string ConnectionString = File.ReadAllText("./connectionstring");
            // DataContext Context = new DataContext( DbContextOptionsBuilder options => options.UseSqlServer(ConnectionString));
            // DataContext Context = new DataContext();

            DbContextOptions<DataContext> ContextOptions = new DbContextOptionsBuilder<DataContext>().UseSqlServer(ConnectionString).Options;

            DataContext Context = new DataContext( ContextOptions );

        }
    }

    class Pet{

        // Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cuteness { get; set; }
        public long Chaos { get; set; }
        public string Species { get; set; }

        // Constructors

        // Methods
        public string Speak()
        {
            return $"Hello, I'm {this.Name}";
        }

    }

    class DataContext : DbContext
    {
        // Fields
        public DbSet<Pet> Pets => Set<Pet>();

        //Constructors
        public DataContext( DbContextOptions<DataContext> options ) : base( options ) {}

    }
}

// CLI Steps 

/*
    nuget - dotnet package manager
*/

// dotnet tool install --global dotnet -ef
// dotnet tool update --global dotnet -ef 
// dotnet add package Microsoft.EntityFrameworkCore.Design
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer