
using CircusTrein;
using System.Drawing;

//Amount of animals to be sorted

//Possible weight values to select from in randomizer.
int[] wValues = { 1, 3, 5 };
Random r = new Random();


///Create list of animals
///Fill list with N amount of animals
///Randomize Type and Size
List<Animal> animals = new List<Animal>();
void InstantiateAnimals(int n) {
    for (int i = 0; i < n; i++)
    {
        animals.Add(new Animal(r.Next(100) <= 50 ? "Carnivore" : "Herbivore", wValues[r.Next(0, wValues.Length)]));
        Console.Write($"Animal Type: " + (animals[i].Type));
        Console.WriteLine(" Weight: " + animals[i].Weight);
    }
    //After Animals are created , Call sorting method
   FillWagons();
}

void FillWagons() {
    ///Create an instance of the packer and give it the list of animals
    ///Distribute the animals and print the status of every wagon
    AnimalPacker packer = new AnimalPacker(animals);
    packer.Pack();
    packer.DisplayWagonAnimals();
}


Console.WriteLine("How many animals to pack:");

// Create a string variable and get user input from the keyboard and store it in the variable
int n  = int.Parse(Console.ReadLine());
InstantiateAnimals(n);
