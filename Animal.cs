using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
   

    public class Animal
    {
        public string Type { get; set; }
        public int Weight { get; set; }

        public Animal(string _type, int _weight)
        {
            Type = _type;
            Weight = _weight;
        }
    }
}
