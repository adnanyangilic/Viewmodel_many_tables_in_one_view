using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using View3model.Models;

namespace View3model.ViewModels
{
    public class VeggyVM
    {
        public IEnumerable<Fruit> Fruits { get; set; }
        public IEnumerable<Vegetable> Vegetables { get; set; }

        public IEnumerable<Legume> Legumes { get; set; }
        public IEnumerable<Grain> Grains { get; set; }
    }
}
