using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public int Capacity { get; set; }

        public List<Shark> Species {  get; set; }

        public int GetCount { get { return Species.Count; } }

        public void AddShark(Shark shark)
        {
            if (Species.Count < Capacity && Species.All(k => k.Kind != shark.Kind))
            {
                Species.Add(shark);
            }
        }

        public bool RemoveShark(string kind)
        {
            if (Species.Any(k => k.Kind == kind))
            {
                Species.RemoveAll(k => k.Kind == kind);
                return true;
            }

            return false;
        }

        public string GetLargestShark()
        {
            return Species.OrderByDescending(l => l.Length).First().ToString();
        }

        public double GetAverageLength()
        {
            double lengthSum = 0;

            foreach (var shark in Species)
            {
                lengthSum += shark.Length;
            }

            double averageLength = lengthSum / Species.Count;

            return averageLength;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Species.Count} sharks classified:");

            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
