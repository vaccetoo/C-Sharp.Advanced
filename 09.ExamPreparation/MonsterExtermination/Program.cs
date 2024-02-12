
int[] monsterArmorsAmmounts = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] soldiersAttacksAmmounts = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> monstersArmor = new Queue<int>(monsterArmorsAmmounts);
Stack<int> soldiersAttack = new Stack<int>(soldiersAttacksAmmounts);

int killedMonsters = 0;

while (monstersArmor.Any() && soldiersAttack.Any())
{
    int currentAttack = soldiersAttack.Peek();
    int currentArmor = monstersArmor.Peek();

    if (currentAttack >= currentArmor)
    {
        killedMonsters++;

        monstersArmor.Dequeue();

        int decreasedAttack = currentAttack - currentArmor;
        soldiersAttack.Pop();

        if (soldiersAttack.Count >= 0 && decreasedAttack > 0)
        {
            if (soldiersAttack.Count == 0)
            {
                soldiersAttack.Push(decreasedAttack);
            }
            else
            {
                int nextAttack = soldiersAttack.Peek();
                soldiersAttack.Pop();

                soldiersAttack.Push(nextAttack + decreasedAttack);
            }
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