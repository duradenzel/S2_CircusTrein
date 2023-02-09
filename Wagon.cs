using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    public class Wagon
    {
        public int RemainingCapacity { get; set; }
        public List<Animal> Animals { get; set; }

        public Wagon(int capacity)
        {
            RemainingCapacity = capacity;
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal _animal)
        {
            RemainingCapacity -= _animal.Weight;
            Animals.Add(_animal);
        }
    }
}
