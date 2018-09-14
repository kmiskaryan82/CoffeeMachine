using CoffeeMachine.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Controllers
{
    public class ResourceController
    {
        public bool IsEnoughResources(Coffee coffee)
        {
            using (CoffeeMachineContext context = new CoffeeMachineContext())
            {
                return context.Reasources.FirstOrDefault(w => w.ResourceID == 1).Count >= coffee.WaterCount
                    && context.Reasources.FirstOrDefault(c => c.ResourceID == 2).Count >= coffee.CoffeeCount
                    && context.Reasources.FirstOrDefault(s => s.ResourceID == 3).Count >= coffee.SugarCount;
            }
        }
        public void CalculateResource(Coffee coffee)
        {
            using (CoffeeMachineContext context = new CoffeeMachineContext())
            {
                var restOfWater = context.Reasources.FirstOrDefault(w => w.ResourceID == 1).Count -= coffee.WaterCount;
                var restOfCoffee = context.Reasources.FirstOrDefault(c => c.ResourceID == 2).Count -= coffee.CoffeeCount;
                var restOfSugar = context.Reasources.FirstOrDefault(s => s.ResourceID == 3).Count -= coffee.SugarCount;
                context.SaveChanges();
            }
        }
    }
}
