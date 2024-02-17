
int[] moneyArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] foodArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> money = new Stack<int>(moneyArray);
Queue<int> food = new Queue<int>(foodArray);

int boughtFood = 0;

while (money.Any() && food.Any())
{
    int currentMoney = money.Peek();
    int currentFoodPrice = food.Peek();

    if (currentMoney == currentFoodPrice)
    {
        boughtFood++;

        money.Pop();
        food.Dequeue();
    }
    else if (currentMoney > currentFoodPrice)
    {
        boughtFood++;

        int change = currentMoney - currentFoodPrice;

        money.Pop();

        if (money.Any())
        {
            money.Push(money.Pop() + change);
            food.Dequeue();
        }
        else
        {
            food.Dequeue();
            break;
        }
    }
    else
    {
        money.Pop();
        food.Dequeue();
    }
}

if (boughtFood >= 4)
{
    Console.WriteLine($"Gluttony of the day! Henry ate {boughtFood} foods.");
}
else if (boughtFood > 0)
{
    if (boughtFood == 1)
    {
        Console.WriteLine($"Henry ate: {boughtFood} food.");
    }
    else
    {
        Console.WriteLine($"Henry ate: {boughtFood} foods.");
    }
}
else
{
    Console.WriteLine("Henry remained hungry. He will try next weekend again.");
}