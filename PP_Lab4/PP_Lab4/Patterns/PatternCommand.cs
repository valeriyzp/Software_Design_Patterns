using System;

namespace PP_Lab4.Patterns
{
    public interface ICommand
    {
        public void MakeOrder();

    }

    public class ChefCook
    {
        public string Name { get; set; }

        public ChefCook(string name)
        {
            Name = name;
        }

        public void MakePizza()
        {
            Console.WriteLine($"Chef cook {Name} get pizza order");
        }

        public void MakeSushi()
        {
            Console.WriteLine($"Chef cook {Name} get sushi order");
        }
    }

    public class PizzaCommand : ICommand
    {
        private ChefCook ChefCook { get; set; }
        
        public PizzaCommand(ChefCook chefCook)
        {
            ChefCook = chefCook;
        }

        public void MakeOrder()
        {
            ChefCook.MakePizza();
        }
    }

    public class SushiCommand : ICommand
    {
        private ChefCook ChefCook { get; set; }

        public SushiCommand(ChefCook chefCook)
        {
            ChefCook = chefCook;
        }

        public void MakeOrder()
        {
            ChefCook.MakeSushi();
        }
    }

    public class Client
    {
        public ICommand Command { get; set; }

        public Client() { ;}

        public Client(ICommand command)
        {
            SetCommand(command);
        }

        public void SetCommand(ICommand command)
        {
            Command = command;
        }

        public void MakeOrder()
        {
            Command.MakeOrder();
        }
    }
}
