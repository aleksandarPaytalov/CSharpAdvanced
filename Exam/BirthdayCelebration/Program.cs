Queue<int> guests = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Stack<int> plates = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int wastedFood = 0;
while (guests.Any() && plates.Any())
{
    int currentGuest = guests.Dequeue(); // с dequeue -> Ако в последния случай имаме госта > от храната -> тогава госта няма да е нахранен, и няма да го има в кюто guest. Ако има такъв кейс трябва да направим нова 
    // колекция queue, в която да пренаредим в правилния ред гостите, защото ако го dequeue и после queue, то госта ще иде в края, което не е правилно и при принтирането ще даде грешка.
    // Еветуално може да се запази последния гост остатъка от числото му, след като се извади колкото храна му е дадена в един нов Queue и после да се добавят останалите от стария 
    // може и да има кейс в който ако госта не е нахранен трябва да върнем първоначалната му стойност /което означава, че трябва да я запазим някъде преди това
    int currentPlate = plates.Pop();

    if (currentPlate >= currentGuest)
    {
        wastedFood += currentPlate - currentGuest;
    }
    else
    {        
        while (currentGuest > currentPlate)
        {
            currentGuest -= currentPlate;
            currentPlate = plates.Pop();            
        }
        wastedFood += Math.Abs(currentGuest - currentPlate);
    }
}

if (!guests.Any())
{
    Console.WriteLine($"Plates: {string.Join(" ", plates)}"); 
    Console.WriteLine($"Wasted grams of food: {wastedFood}");
}
else
{
    Console.WriteLine($"Guests: {string.Join(" ", guests)}"); 
    Console.WriteLine($"Wasted grams of food: {wastedFood}");
}