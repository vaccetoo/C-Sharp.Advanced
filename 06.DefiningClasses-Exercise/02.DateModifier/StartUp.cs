
namespace DateModifier;

class StartUp
{
    public static void Main()
    { 
        string firstDate = Console.ReadLine();  
        string secondDate = Console.ReadLine();

        int difference = DateModifier.GetDifferenceInDates(firstDate, secondDate);

        Console.WriteLine(difference);
    }
}