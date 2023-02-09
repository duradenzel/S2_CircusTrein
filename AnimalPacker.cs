using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CircusTrein.Animal;

namespace CircusTrein
{
    public class AnimalPacker
    {

        private List<Animal> animals;
        private List<Wagon> wagons;

        public AnimalPacker(List<Animal> _animals)
        {
            this.animals = _animals;
            wagons = new List<Wagon>();
        }

        public void Pack()
        {
            // Sort animals in descending order of weight
            animals.Sort((a, b) => b.Weight.CompareTo(a.Weight));

            // Distribute animals into wagons
            foreach (Animal animal in animals)
            {
                bool added = false;
                foreach (Wagon wagon in wagons)
                {
                    if (wagon.RemainingCapacity >= animal.Weight && !Conflicts(animal, wagon))
                    {
                        wagon.AddAnimal(animal);
                        added = true;
                        break;
                    }
                }
                if (!added)
                {
                    Wagon newWagon = new Wagon(10);
                    newWagon.AddAnimal(animal);
                    wagons.Add(newWagon);
                }
            }
        }

        private bool Conflicts(Animal newAnimal, Wagon wagon)
        {
            if (newAnimal.Type == "Carnivore")
            {
                foreach (Animal wagonAnimal in wagon.Animals)
                {
                    if (wagonAnimal.Type == "Carnivore" || wagonAnimal.Weight >= newAnimal.Weight)
                    {
                        return true;
                    }
                }
            }
            else if (newAnimal.Type == "Herbivore")
            {
                foreach (Animal wagonAnimal in wagon.Animals)
                {
                    if (wagonAnimal.Weight >= newAnimal.Weight && wagonAnimal.Type == "Carnivore")
                    {
                        return true;
                    }
                }
            }
                return false;
        }

        public void DisplayWagonAnimals()
        {
            int i = 1;
            foreach (Wagon wagon in wagons)
            {
                Console.WriteLine("Wagon " + i + ":");
                foreach (Animal animal in wagon.Animals)
                {
                    Console.WriteLine("\t" + animal.Type + " of weight " + animal.Weight);
                }
                Console.WriteLine();
                i++;
            }
            Console.WriteLine("Total amount of wagons needed: " + wagons.Count);
        }
    }
}
