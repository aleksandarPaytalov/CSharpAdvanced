int greenLight = int.Parse(Console.ReadLine());
int freeWindow =int.Parse(Console.ReadLine());

Queue<string> carsInQueue = new();
string input = Console.ReadLine();
int totalCarsPassed = 0;

while (input != "END")
{
    if (input != "green")
    {
        carsInQueue.Enqueue(input);
    }
    else
    {        
        int secondsCounter = greenLight + freeWindow;

        while (secondsCounter > 0 && secondsCounter > freeWindow && carsInQueue.Any()) // да се имплементира че кола не трябва да влиза по време на зеления прозорец
        {
            string currentVehicle = carsInQueue.Dequeue();

            if (currentVehicle.Length > secondsCounter)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{currentVehicle} was hit at {currentVehicle[secondsCounter]}.");
                return;
            }
            else
            {
                if (secondsCounter <= freeWindow)
                {
                    break;
                }
                totalCarsPassed++;
                secondsCounter -= currentVehicle.Length;  //1       
            }
        }        
    }

    input = Console.ReadLine();
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");