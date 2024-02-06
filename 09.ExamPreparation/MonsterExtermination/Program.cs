
int[] monsterArmorsAmmounts = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] soldiersAttacksAmmounts = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> monstersArmor =  new Queue<int>(monsterArmorsAmmounts);
Stack<int> soldiersAttack =  new Stack<int>(soldiersAttacksAmmounts);

int killedMonsters = 0;

while (monstersArmor.Any() && soldiersAttack.Any())
{
    int currentAttack = soldiersAttack.Peek();
    int currentArmor = monstersArmor.Peek();

    if (currentAttack >= currentArmor)
    {
        killedMonsters++;

        monstersArmor.Dequeue();

        int newAttackValue = currentAttack - currentArmor;
        soldiersAttack.Pop();

        if (newAttackValue > 0)
        {
            soldiersAttack.Push(newAttackValue);
        }
    }
    else
    {
        int monsterNewArmor = currentArmor - currentAttack;
        monstersArmor.Dequeue();
        monstersArmor.Enqueue(monsterNewArmor);

        soldiersAttack.Pop();
    }

    if (!monstersArmor.Any())
    {
        Console.WriteLine($"All monsters have been killed!");
    }
}

if (!soldiersAttack.Any())
{
    Console.WriteLine($"The soldier has been defeated.");
}

Console.WriteLine($"Total monsters killed: {killedMonsters}");