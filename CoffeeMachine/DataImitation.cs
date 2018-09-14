using CoffeeMachine.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public static class DataImitation
    {
        public static List<Coffee> GenerateData(int count)
        {
            int[] prices = { 50, 100, 200 };
            double[] waterCount = { 1, 2, 3 };
            double[] cofeeCount = { 0.1, 0.2, 0.3 };
            double[] sugarCount = { 0.1, 0.2, 0.3 };

            Random rnd = new Random();

            List<Coffee> coffees = new List<Coffee>();
            for (int i = 1; i < count + 1; i++)
            {
                Coffee coffee = new Coffee()
                {
                    Name = $"Coffee {i}",
                    Price = prices[rnd.Next(prices.Length)],
                    CoffeeCount = cofeeCount[rnd.Next(cofeeCount.Length)],
                    SugarCount = sugarCount[rnd.Next(sugarCount.Length)],
                    WaterCount = waterCount[rnd.Next(waterCount.Length)],
                };
                coffees.Add(coffee);
            }

            Resource waterRes = new Resource()
            {
                ResourceName = "water",
                Count = 10
            };
            Resource coffeeRes = new Resource()
            {
                ResourceName = "coffee",
                Count = 5
            };
            Resource sugarRes = new Resource()
            {
                ResourceName = "sugar",
                Count = 5
            };
            using (CoffeeMachineContext context = new CoffeeMachineContext())
            {
                context.Coffees.AddRange(coffees);
                context.Reasources.Add(waterRes);
                context.Reasources.Add(coffeeRes);
                context.Reasources.Add(sugarRes);
                context.SaveChanges();
            }
            return coffees;
        }
    }
}








