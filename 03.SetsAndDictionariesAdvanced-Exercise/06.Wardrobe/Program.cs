
int inputCount = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> clothesCount =
    new Dictionary<string, Dictionary<string, int>>();

for (int i = 0; i < inputCount; i++)
{
    string[] colorAndClothes = Console.ReadLine()
        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

    string currentColor = colorAndClothes[0];

    string[] currentClothes = colorAndClothes[1].Split(",");

    if (!clothesCount.ContainsKey(currentColor))
    {
        clothesCount.Add(currentColor, new Dictionary<string, int>());
    }

    foreach (var cloth in currentClothes)
    {
        if (!clothesCount[currentColor].ContainsKey(cloth))
        {
            clothesCount[currentColor].Add(cloth, 0);
        }

        clothesCount[currentColor][cloth]++;
    }
}

string[] clothLookingFor = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string clothColorToFind = clothLookingFor[0];
string clothNameToFind = clothLookingFor[1];

foreach (var (color, cloth) in clothesCount)
{
    Console.WriteLine($"{color} clothes:");

    string currentColor = color;

    foreach (var (currentCloth, count) in cloth)
    {
        if (currentColor == clothColorToFind && currentCloth == clothNameToFind)
        {
            Console.WriteLine($"* {currentCloth} - {count} (found!)");
        }
        else
        {
            Console.WriteLine($"* {currentCloth} - {count}");
        }
    }
}
