public class Car
{
    private readonly IEngine _engine;

    public Car (IEngine engine)
    {
        _engine = engine;
    }

    public void printEngineDetails()
    {
        Console.WriteLine( $"" );
        Console.WriteLine( $"" );
    }
}