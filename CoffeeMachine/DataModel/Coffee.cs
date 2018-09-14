using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.DataModel
{
    public class Coffee
    {
        [Required]
        public int CoffeeId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
       
        public double WaterCount { get; set; }
        public double CoffeeCount { get; set; }
        public double SugarCount { get; set; }

    }
}
