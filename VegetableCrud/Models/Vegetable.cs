using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VegetableCrud.Models
{
    public class Vegetable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        [Display(Name="Price per ton")]
        public int PricePerTon { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Farmer name")]
        public string FarmerName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Production state")]
        public string ProductionState { get; set; }
    }
}