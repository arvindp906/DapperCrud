using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DapperCrudOperation.Models
{
    public class Vegetable
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        [MinLength(4)]
        public string Type { get; set; }
        [Required]
        public int PricePerTon { get; set; }
        [Required]
        
        public string FarmerName { get; set; }
        [Required]
        [MinLength(5)]
        public string ProductionState { get; set; }
    }
}