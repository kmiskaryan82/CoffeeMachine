using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.DataModel;





namespace CoffeeMachine.Controllers
{
    public class CoffeeMachineController
    {

        public ICollection<Coffee> GetCoffees()
        {
            List<Coffee> coffees = new List<Coffee>();

            using (CoffeeMachineContext context = new CoffeeMachineContext())
            {
                coffees = context.Coffees.ToList();
            }
            return coffees;
        }

        public Coffee SelectCoffee(int id)
        {
            Coffee coffee = new Coffee();
            using (CoffeeMachineContext context = new CoffeeMachineContext())
            {
                coffee = context.Coffees.FirstOrDefault(c => c.CoffeeId == id);
            }
            return coffee;
        }

        public bool IsValidCoin(int coin)
        {
            if (coin == 50 || coin == 100 || coin == 200 || coin == 500)
            {
                return true;
            }
            return false;
        }
    }
}

