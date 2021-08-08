using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace View3model.Models
{
    public class Legume
    {

        [Key]
        public int LegumeId { get; set; }
        public string LegumeName { get; set; }
    }
}
