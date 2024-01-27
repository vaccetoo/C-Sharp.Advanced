using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = 0;
            Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder();

            carInfo.AppendLine($"{Model}:");
            carInfo.AppendLine($"  {Engine.Model}:");
            carInfo.AppendLine($"    Power: {Engine.Power}");

            if (Engine.Displacement == 0)
            {
                carInfo.AppendLine($"    Displacement: n/a");
            }
            else
            {
                carInfo.AppendLine($"    Displacement: {Engine.Displacement}");
            }

            carInfo.AppendLine($"    Efficiency: {Engine.Efficiency}");

            if (Weight == 0)
            {
                carInfo.AppendLine($"  Weight: n/a");
            }
            else
            {
                carInfo.AppendLine($"  Weight: {Weight}");
            }
            carInfo.AppendLine($"  Color: {Color}");

            return carInfo.ToString().TrimEnd();
        }
    }
}
