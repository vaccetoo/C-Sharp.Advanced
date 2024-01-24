using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public List<Person> People { get { return people; } set { people = value; } }


        public Person GetOldestMember()
        {
            return people.MaxBy(person => person.Age);
        }
    }
}
