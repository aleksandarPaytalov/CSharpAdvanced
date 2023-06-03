namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {             
            List<Tire[]> tiresCollection = new();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                double[] tiresInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                Tire[] tires = new Tire[4]
                {                     
                 new Tire ((int)tiresInfo[0], tiresInfo[1]),
                 new Tire ((int)tiresInfo[2], tiresInfo[3]),
                 new Tire ((int)tiresInfo[4], tiresInfo[5]),
                 new Tire ((int)tiresInfo[6], tiresInfo[7])                    
                };

                tiresCollection.Add(tires);
            }

            List<Engine> engineCollection = new();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                double[] engineInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                int horsePower = (int)engineInfo[0];
                double cubicCapacity = engineInfo[1];

                Engine currentEngine = new(horsePower, cubicCapacity);
                engineCollection.Add(currentEngine);
            }

            List<Car> specialCars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car currentCar = new(make, model, year, fuelQuantity, fuelConsumption, engineCollection[engineIndex], tiresCollection[tiresIndex]);
                specialCars.Add(currentCar);
            }

            List<Car> filteredSpecialCars =
                specialCars.Where(c => c.Year >= 2017)
                .Where(e => e.Engine.HorsePower > 330)
                .Where(t => t.Tires.Sum(p => p.Pressure) >= 9 && t.Tires.Sum(p => p.Pressure) <= 10)
                .ToList();

            foreach (var car in filteredSpecialCars)
            {
                car.Drive(20);

                Console.WriteLine(car.WhoAmI());
            }

        }
    }
}

