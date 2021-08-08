using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace View3model.Models
{
    public class Grain
    {
     [Key]
     public int GrainId { get; set; }
     public string  GrainName { get; set; }

    }
}
