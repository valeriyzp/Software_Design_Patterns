using System;
using System.Collections.Generic;
using PP_Lab4.Patterns;

namespace PP_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            showMemento();
            showState();
            showCommand();
            showInterpreter();
            showTemplateMethod();
        }

        static void showMemento()
        {
            Console.WriteLine("Memento:");

            GraphicEditor Paint = new GraphicEditor();
            Paint.AddShape("Dot");
            Paint.AddShape("Circle");
            Paint.Save();
            Paint.AddShape("Square");

            Console.WriteLine("Before undo: ");
            Paint.ShowPicture();

            Paint.Undo();

            Console.WriteLine("After undo: ");
            Paint.ShowPicture();

            Console.WriteLine();
        }

        static void showState()
        {
            Console.WriteLine("State:");

            Smartphone MeizuM6s = new Smartphone();

            MeizuM6s.Tap();
            MeizuM6s.BlockButton();
            MeizuM6s.Tap();
            MeizuM6s.Tap();
            MeizuM6s.BlockButton();

            Console.WriteLine();
        }

        static void showCommand()
        {
            Console.WriteLine("Command:");

            ChefCook Valeriy = new ChefCook("Valeriy");
            Client IlonMask = new Client(new PizzaCommand(Valeriy));

            Console.WriteLine("Client make order: ");
            IlonMask.MakeOrder();

            IlonMask.SetCommand(new SushiCommand(Valeriy));

            Console.WriteLine("Client make order: ");
            IlonMask.MakeOrder();

            Console.WriteLine();
        }

        static void showInterpreter()
        {
            Console.WriteLine("Interpreter:");

            Context Parametrs = new Context(new Dictionary<char, int>() { { 'x', 3 }, { 'y', 2 }, { 'z', 1 } });
            Console.WriteLine("x = 3, y = 2, z = 1 ");

            IExpression MathExpression = new Add(new Add(new Number('x'), new Number('y')), new Inversion(new Number('z')));

            Console.Write("(x + y) + -z = ");
            Console.WriteLine(MathExpression.Interpret(Parametrs));

            MathExpression = new Add(new Inversion(new Add(new Number('x'), new Number('y'))), new Inversion(new Number('z')));

            Console.Write("-(x + y) + -z = ");
            Console.WriteLine(MathExpression.Interpret(Parametrs));

            Console.WriteLine();
        }

        static void showTemplateMethod()
        {
            Console.WriteLine("Template method:");

            CarMaker Manufacturer = new FordCar();

            Console.WriteLine("Manufacturer make car: ");
            Manufacturer.MakeBody();
            Manufacturer.Paint();
            Manufacturer.StickLogo();

            Manufacturer = new ZAZCar();

            Console.WriteLine("Manufacturer make car: ");
            Manufacturer.MakeBody();
            Manufacturer.Paint();
            Manufacturer.StickLogo();

            Console.WriteLine();
        }
    }
}
