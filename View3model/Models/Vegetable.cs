using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace View3model.Models
{
    public class Vegetable
    {
        [Key]
        public int VegetableId { get; set; }
        public string VegetableName { get; set; }
    }
}
