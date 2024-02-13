using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            if (Clothes.Any(c => c.Color == color))
            {
                Clothes.RemoveAll(c => c.Color == color);
                return true;
            }

            return false;
        }

        public Cloth GetSmallestCloth()
        {
            return Clothes.OrderBy(s => s.Size).First();
        }

        public Cloth GetCloth(string color)
        {
            return Clothes.First(c => c.Color == color);
        }

        public int GetClothCount()
        {
            return Clothes.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Type} magazine contains:");

            foreach ( var cloth in Clothes.OrderBy(s => s.Size))
            {
                sb.AppendLine(cloth.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
