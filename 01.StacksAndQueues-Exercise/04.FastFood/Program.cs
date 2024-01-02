
int foodQuantity = int.Parse(Console.ReadLine()); // 348

Queue<int> orders
    = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray()); // 20 54 30 16 7 9

Console.WriteLine(orders.Max()); // 54

while (foodQuantity > 0 && orders.Any())
{
    int currentOrder = orders.Peek();

    if (foodQuantity - currentOrder >= 0)
    {
        orders.Dequeue();
        foodQuantity -= currentOrder;
        continue;
    }

    break;
}

if (orders.Any())
{
    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
}
else
{
    Console.WriteLine("Orders complete");
}

