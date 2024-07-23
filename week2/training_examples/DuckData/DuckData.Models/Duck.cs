namespace DuckData.Models
{
    public class Duck
    {
        public int ID { get; set; }
        public string color { get; set; }
        public int numFeathers { get; set; }
        private static int IDCounter = 0;

        public Duck ( int ID, string color, int numFeathers )
        {
            this.ID = ID;
            this.color = color;
            this.numFeathers = numFeathers;
        }

        public Duck( string color, int numFeathers )
        {
            this.ID = IDCounter;
            this.color = color;
            this.numFeathers = numFeathers;
            IDCounter++;
        }

        public Duck(){}

        public void Quack()
        {
            Console.WriteLine( "Quack! I'm {0}", color );
        }

        public override string ToString()
        {
            return $"{this.ID} {this.color} {this.numFeathers}";
        }

        
    }
}

