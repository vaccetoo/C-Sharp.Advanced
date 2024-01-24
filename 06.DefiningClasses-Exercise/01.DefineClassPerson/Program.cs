
namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        // Logic 2:

        int peopleCnt = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < peopleCnt; i++)
        {
            string[] personInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);

            Person person = new Person(name, age);

            people.Add(person);
        }

        foreach (Person person in people.Where(a => a.Age > 30).OrderBy(n => n.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }

            // Logic 1:

            //int peopleCnt = int.Parse(Console.ReadLine());

            //Family family = new Family();

            //for (int i = 0; i < peopleCnt; i++)
            //{
            //    string[] personInfo = Console.ReadLine()
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //    string name = personInfo[0];
            //    int age = int.Parse(personInfo[1]);

            //    Person person = new Person(name, age);

            //    family.People.Add(person);
            //}

            //Person oldestMember = family.GetOldestMember();

            //Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
}