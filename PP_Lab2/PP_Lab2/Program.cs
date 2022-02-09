using System;
using PP_Lab2.Patterns;

namespace PP_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAdapter();
            ShowDecorator();
            ShowProxy();
            ShowComposite();
            ShowBridge();
            ShowFlyweight();
            ShowFacade();
        }

        static void ShowAdapter()
        {
            Console.WriteLine("Adapter:");

            AmericanMetric PersonInfo = new AmericanMetric(6, 183);

            Console.WriteLine("Person information in American metric:");
            Console.WriteLine(String.Format("Height: {0:0.##} ft.", PersonInfo.FeetHeight));
            Console.WriteLine(String.Format("Weight: {0:0.##} lb.", PersonInfo.PoundWeight));

            IMetric UkrainianMetric = new AmericanToUkrainianMetricAdapter(PersonInfo);

            Console.WriteLine("Person information in Ukrainian metric:");
            Console.WriteLine(String.Format("Height: {0:0.##} m.", UkrainianMetric.getHeight()));
            Console.WriteLine(String.Format("Weight: {0:0.##} kg.", UkrainianMetric.getWeight()));

            Console.WriteLine();
        }

        static void ShowDecorator()
        {
            Console.WriteLine("Decorator:");

            IHuman Valeriy = new Human("Valeriy");
            Valeriy = new FootDecorator(Valeriy, "Socks");
            Valeriy = new FootDecorator(Valeriy, "Pants");
            Valeriy = new BodyDecorator(Valeriy);
            Console.WriteLine(Valeriy.showСlothes());

            Console.WriteLine();
        }

        static void ShowProxy()
        {
            Console.WriteLine("Proxy:");

            IDataBase MyDataBase = new DataBaseProxy();
            Console.WriteLine("Proxy DataBase created, but not initialized");
            Console.WriteLine("Data in DataBase: {0}", MyDataBase.get());
            MyDataBase.set("Valeriy Kozlov");
            MyDataBase.set("Valeriy Kozlov");

            Console.WriteLine();
        }

        static void ShowComposite()
        {
            Console.WriteLine("Composite:");

            PackageBox Smartphone = new PackageBox("Smartphone");
            Smartphone.add(new Package("Meizu M6s"));
            Smartphone.add(new Package("Power supply"));
            Smartphone.add(new Package("Warranty"));

            PackageBox Gift = new PackageBox("Gift box");
            Gift.add(new Package("Headphones"));
            Gift.add(Smartphone);
            Gift.add(new Package("Candy"));

            Console.WriteLine("Gift consists of: ");
            Gift.showInfo();

            Console.WriteLine();
        }

        static void ShowBridge()
        {
            Console.WriteLine("Bridge:");

            ICar FordMustang = new Ford();
            CarKey SimpleKey = new CarKey(FordMustang);
            AdvancedCarKey AdvancedKey = new AdvancedCarKey(FordMustang);

            SimpleKey.startEngine();
            AdvancedKey.startEngine();
            AdvancedKey.blinkHeadlights();
            AdvancedKey.stopEngine();

            Console.WriteLine();
        }

        static void ShowFlyweight()
        {
            Console.WriteLine("Flyweight:");

            Parking MyParking = new Parking();
            MyParking.addCar("Ford Mustang GT", "AA0001AA");
            MyParking.addCar("Ford Mustang GT", "AA0002AA");
            MyParking.addCar("Ford Fusion", "AA0003AA");
            MyParking.addCar("Ford Fusion", "AA0004AA");
            MyParking.addCar("Ford Fusion", "AA0005AA");

            Console.WriteLine("Cars in parking:");
            MyParking.showCars();
            Console.WriteLine("Cars count: {0}", MyParking.Cars.Count);
            Console.WriteLine("Car types count: {0}", MyParking.CarFactory._CarTypes.Count);

            Console.WriteLine();
        }

        static void ShowFacade()
        {
            Console.WriteLine("Facade:");

            ServiceStation SimpleSTO = new ServiceStation();
            SimpleSTO.ServiceCar();

            Console.WriteLine();
        }
    }
}
