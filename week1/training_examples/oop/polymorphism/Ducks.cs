namespace Polymorphism;

public class Duck {

    public string wings { get; set; }
    public int weight { get; set; }

    public virtual void swim() {
        Console.WriteLine("Duck is swimming");
    }

    public void Quack() {
        Console.WriteLine("Duck is quacking");
    }
}