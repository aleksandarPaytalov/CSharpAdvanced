using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year)  :this() /// ????
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;          
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;   
            this.Tires = tires;      
        }
       
        public string Make
        { 
            get { return this.make; }
            set { this.make = value; }        
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }        
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }        
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }        
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }


        public void Drive(double distance)
        {
            double fuelNeed = FuelConsumption * distance / 100;
            if (FuelQuantity - fuelNeed < 0) // тук лектора сложи името на пропъртито FuelQuantity, но аз го направих с филда и също работи. Да се види все пак дали има значение в края на упражнението
                //тук минаваме през пропъртито ако искаме да валидираме данните за съответното поле - затова и двата варианта минават /да се ползва пропъртито, а не филда/
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                FuelQuantity -= fuelNeed;
            }        
        }

        public string WhoAmI()
        {
            StringBuilder print = new StringBuilder();

            print.AppendLine($"Make: {this.Make}");
            print.AppendLine($"Model: {this.Model}");
            print.AppendLine($"Year: {this.Year}");            
            print.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            print.AppendLine($"FuelQuantity: {this.FuelQuantity}");

           // int count = 1;
           //foreach (var tire in tires)
           //{
           //    print.AppendLine($"Tire {count}: {tire.Year} - {tire.Pressure}");
           //    count++;
           //}            

            return print.ToString().Trim(); // препоръчва се да го пишем така на изпита !!
        }
    }
}
