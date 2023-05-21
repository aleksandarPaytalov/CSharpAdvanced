SortedDictionary<string, List<string>> shopsProducts = new(); // може и с второ вложено Dictionary вместо по-долу да се създава втори нов
string input = string.Empty;

while ((input = Console.ReadLine()) != "Revision")
{
    string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string storeName = info[0];
    string productNameAndPrice = $"{info[1]} {info[2]}";

    if (!shopsProducts.ContainsKey(storeName))
    {
        shopsProducts.Add(storeName, new List<string>());    
    }
    shopsProducts[storeName].Add(productNameAndPrice);
}
Dictionary<string, double> products = new();
foreach (var item in shopsProducts)
{
    products = new();
    for (int i = 0; i < item.Value.Count; i++)
    {        
        string[] productInfo = item.Value[i].Split(" ").ToArray();
        string productName = productInfo[0];
        double productPrice = double.Parse(productInfo[1]);

        if (!products.ContainsKey(productName))
        {
            products.Add(productName, 0);
        }
        products[productName] = productPrice;
    }
    Console.WriteLine($"{item.Key}->");
    foreach (var product in products)
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
    
}