using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Child> Registry { get; set; }

        public int ChildrenCount { get { return Registry.Count; } }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] nameParts = childFullName
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstName = nameParts[0];
            string lastName = nameParts[1];

            foreach (var child in Registry)
            {
                if (child.FirstName == firstName && child.LastName == lastName)
                {
                    Registry.Remove(child);
                    return true;
                }
            }

            return false;
        }

        public Child GetChild(string childFullName)
        {
            string[] nameParts = childFullName
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstName = nameParts[0];
            string lastName = nameParts[1];

            return Registry.Where(f => f.FirstName == firstName).Where(s => s.LastName == lastName).First();
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry.OrderByDescending(a => a.Age).ThenBy(l => l.LastName).ThenBy(f => f.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
