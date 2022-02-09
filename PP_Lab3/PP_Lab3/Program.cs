using System;
using System.Collections.Generic;
using PP_Lab3.Patterns;

namespace PP_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            showIterator();
            showMediator();
            showObserver();
            showStretegy();
            showChainOfResponsibility();
            showVisitor();
        }

        static void showIterator()
        {
            Console.WriteLine("Iterator:");

            Queue IntArray = new Queue();
            for (int i = 1; i <= 5; ++i)
                IntArray.Add(i);

            IIterator Front = IntArray.createFrontIterator();
            IIterator Back = IntArray.createBackIterator();

            Console.WriteLine("Front iterator: ");
            while (!Front.isEnd())
                Console.Write(Front.getNext() + " ");
            Console.WriteLine();

            Console.WriteLine("Back iterator: ");
            while (!Back.isEnd())
                Console.Write(Back.getNext() + " ");
            Console.WriteLine();

            Console.WriteLine();
        }

        static void showMediator()
        {
            Console.WriteLine("Mediator:");

            Dispatcher AirportDispatcher = new Dispatcher();

            Plane V001 = new Plane("V001", AirportDispatcher);
            Plane V002 = new Plane("V002", AirportDispatcher);
            Airport Heathrow = new Airport("Heathrow", AirportDispatcher);

            AirportDispatcher.DispatcherAirport = Heathrow;
            AirportDispatcher.Planes.Add(V001);
            AirportDispatcher.Planes.Add(V002);

            Heathrow.EmptyRunway();
            V001.TryToLanding();
            Heathrow.NotEmptyRunway();
            V002.TryToLanding();

            Console.WriteLine();
        }

        static void showObserver()
        {
            Console.WriteLine("Observer:");

            Man Valeriy = new Man("Valeriy");
            Woman Maria = new Woman("Maria");
            Man Ilon = new Man("Ilon");

            Store AppleStore = new Store();
            AppleStore.Subscribe(Valeriy);
            AppleStore.Subscribe(Maria);
            AppleStore.Subscribe(Ilon);

            Console.WriteLine("Notify subscribers: ");
            AppleStore.NotifySubscribers();

            Console.WriteLine();
        }

        static void showStretegy()
        {
            Console.WriteLine("Strategy:");

            NewVector<int> Array = new NewVector<int>(new BubbleSort());
            for (int i = 5; i > 0; --i)
                Array.Add(i);

            Console.WriteLine("Before sort: ");
            for (int i = 0; i < Array.Size(); ++i)
                Console.Write(Array[i] + " ");
            Console.WriteLine();

            Array.Sort();
            Console.WriteLine("After bubble sort: ");
            for (int i = 0; i < Array.Size(); ++i)
                Console.Write(Array[i] + " ");
            Console.WriteLine();

            Array.SetStrategy(new ReverseBubbleSort());

            Array.Sort();
            Console.WriteLine("After reverse bubble sort: ");
            for (int i = 0; i < Array.Size(); ++i)
                Console.Write(Array[i] + " ");
            Console.WriteLine();

            Console.WriteLine();
        }

        static void showChainOfResponsibility()
        {
            Console.WriteLine("Chain of responsibility:");

            IHandler Rule = new ErrorHandler();
            Console.WriteLine("One rule handler: ");
            Rule.handle("Data");

            Rule.setNext(new ValidationHandler());
            Console.WriteLine("Two rule handler: ");
            Rule.handle("Information");

            Console.WriteLine();
        }

        static void showVisitor()
        {
            Console.WriteLine("Visitor:");

            Traveller Valeriy = new Traveller();

            List<IElement> Transport = new List<IElement>();
            Transport.Add(new Car("ZAZ 1102 Tavria Nova"));
            Transport.Add(new Airplane("AN-225 Mriya"));
            Transport.Add(new Car("Ford Fusion"));

            Console.WriteLine("Hi, Valeriy. What kind of transport will you travel: ");
            foreach (IElement transport in Transport)
                transport.accept(Valeriy);

            Console.WriteLine();
        }
    }
}
