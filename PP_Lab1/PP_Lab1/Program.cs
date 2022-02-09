using System;
using System.Collections.Generic;
using System.Linq;
using PP_Lab1.Patterns;

namespace PP_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowSingleton();
            ShowPrototype();
            ShowFactoryMethod();
            ShowAbstractFactory();
            ShowBuilder();
        }

        static void ShowSingleton()
        {
            Console.WriteLine("Singletone:");

            ProgrammInformation info = ProgrammInformation.GetProgrammInformation();

            Console.WriteLine("Default information: " + info.Readme);

            info.Readme = "Special for Natalya Oleksiyivna";

            Console.WriteLine("Modified information: " + ProgrammInformation.GetProgrammInformation().Readme);

            Console.WriteLine();
        }

        static void ShowPrototype()
        {
            Console.WriteLine("Prototype:");

            Notebook myNotebook = new Notebook();
            myNotebook.Model = "Lenovo Ideapad 320 IKB";
            myNotebook.WiFiAdapter = "Realtek";

            DesktopComputer myComputer = new DesktopComputer();
            myComputer.Model = "Asus M5QL PRO";
            myComputer.EthernetAdapter = "Realtek";

            List<IComputer> Computers = new List<IComputer>();

            Computers.Add(myNotebook);
            Computers.Add(myNotebook.clone());
            Computers.Add(myComputer);
            Computers.Add(myComputer.clone());

            Console.WriteLine("Computers and copies: ");
            foreach (IComputer computer in Computers)
                Console.WriteLine($"Model: {computer.ToString()}, Class: {computer.GetType().ToString().Split(".").Last()}");

            Console.WriteLine();
        }

        static void ShowFactoryMethod()
        {
            Console.WriteLine("Factory method:");

            List<ITransport> Transport = new List<ITransport>();

            CarFactory carFactory = new CarFactory();
            ShipFactory shipFactory = new ShipFactory();

            Transport.Add(carFactory.Create());
            Transport.Add(shipFactory.Create());

            Console.WriteLine("Transport: ");
            foreach (ITransport transport in Transport)
                Console.WriteLine($"Information: {transport.GetInformation()}, Class: {transport.GetType().ToString().Split(".").Last()}");

            Console.WriteLine();
        }

        static void ShowAbstractFactory()
        {
            Console.WriteLine("Abstract factory: ");

            List<FootballTeam> FootballTeams = new List<FootballTeam>();
            FootballTeams.Add(new FootballTeam(new UkrainianTeam()));
            FootballTeams.Add(new FootballTeam(new PortugalTeam()));

            Console.WriteLine("Football teams: ");
            foreach (FootballTeam footballTeam in FootballTeams)
                Console.WriteLine(footballTeam.GetInformation());

            Console.WriteLine();
        }

        static void ShowBuilder()
        {
            Console.WriteLine("Builder: ");

            Baker ValeriyKozlov = new Baker();
            List<Pizza> myPizzas = new List<Pizza>();
            List<Recipe> myRecipes = new List<Recipe>();

            PizzaMaker myBake = new PizzaMaker();
            RecipePizzaMaker myJournal = new RecipePizzaMaker();

            ValeriyKozlov.MakePepperoni(myBake);
            myPizzas.Add(myBake.getPizza());
            ValeriyKozlov.MakeMargarita(myBake);
            myPizzas.Add(myBake.getPizza());

            ValeriyKozlov.MakePepperoni(myJournal);
            myRecipes.Add(myJournal.getRecipe());
            ValeriyKozlov.MakeMargarita(myJournal);
            myRecipes.Add(myJournal.getRecipe());

            Console.WriteLine("My pizzas: ");
            foreach (Pizza pizza in myPizzas)
                Console.WriteLine(pizza.Name);

            Console.WriteLine("My recipes: ");
            foreach (Recipe recipe in myRecipes)
                Console.WriteLine(recipe.ToString());

            Console.WriteLine();
        }
    }
}
