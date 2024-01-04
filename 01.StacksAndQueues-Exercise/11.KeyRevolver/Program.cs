
int bulletPrice = int.Parse(Console.ReadLine());

int gunBarrelSize  = int.Parse(Console.ReadLine());

int[] bulletsValues = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] locksValues = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int intelligenceValue = int.Parse(Console.ReadLine()); // Also will be used for moneyEarned = intelligence - moneySpend

Queue<int> locks = new Queue<int>(locksValues);

Stack<int> bullets = new Stack<int>(bulletsValues);

int currentBarrelSize = gunBarrelSize;

int moneySpend = 0;

while (bullets.Any() && locks.Any())
{
    int currentLockValue = locks.Peek();
    int currentBulletValue = bullets.Pop();

    moneySpend += bulletPrice;
    currentBarrelSize--;

    if (currentBulletValue <= currentLockValue)
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    if (currentBarrelSize == 0 && bullets.Any())
    {
        Console.WriteLine("Reloading!");
        currentBarrelSize = gunBarrelSize;
    }

    if (!bullets.Any() && locks.Any())
    {
        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
    }
}

if (!locks.Any())
{
    intelligenceValue -= moneySpend;

    Console.WriteLine($"{bullets.Count()} bullets left. Earned ${intelligenceValue}");
}