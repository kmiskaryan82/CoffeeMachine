using CoffeeMachine.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.Controllers;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
           // DataImitation.GenerateData(10);


            ResourceController resourceController = new ResourceController();
            CoffeeMachineController controller = new CoffeeMachineController();

            var coffees = controller.GetCoffees();
            foreach (var coffee in coffees)
            {
                Console.WriteLine(coffee.Name + " - " + coffee.Price);
            }

            Console.WriteLine();
            Console.WriteLine("Select Coffee");

            Coffee selected = null;
            int result = -1;
            while (result == -1)
            {
                try
                {
                    result = Convert.ToInt32(Console.ReadLine());
                    selected = controller.SelectCoffee(result);
                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (!resourceController.IsEnoughResources(selected))
            {
                Console.WriteLine("Not Enough Resorces");
                
            }
            else
            {
                resourceController.CalculateResource(selected);

                Console.WriteLine();
                Console.WriteLine(selected.Name);
                Console.WriteLine(selected.Price);
                Console.WriteLine();
                Console.WriteLine("Enter Coin");

                int coin = 0;
                int total = 0;
                bool isValid = false;
                while (total < selected.Price)
                {
                    try
                    {
                        coin = Convert.ToInt32(Console.ReadLine());
                        isValid = controller.IsValidCoin(coin);
                        if (!isValid)
                        {
                            throw new Exception("Enter only 50,100,200,500");
                        }
                        total += coin;
                        if (coin < selected.Price)
                        {
                            throw new Exception($"Not Enough, please Add {selected.Price - total}");
                        }
                        else
                        {
                            if (coin > selected.Price)
                            {
                                Console.WriteLine("Enjoy Your Coffee");
                                Console.WriteLine($"Please Take Your Change {total - selected.Price}");
                            }
                            else
                            {
                                Console.WriteLine("Enjoy Your Coffee");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.WriteLine();
            Console.ReadLine();
           
        }
    }
}
