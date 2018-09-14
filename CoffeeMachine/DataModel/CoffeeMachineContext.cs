namespace CoffeeMachine.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CoffeeMachineContext : DbContext
    {
        
        public CoffeeMachineContext()
            : base("name=CoffeeMachineContext")
        {
        }
        
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Resource> Reasources { get; set; }


    }

  
}