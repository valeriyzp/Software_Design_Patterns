using System;
using System.Collections.Generic;

namespace PP_Lab2.Patterns
{
    public class CarType
    {
        public string Type { get; }

        public CarType(string type)
        {
            Type = type;
        }

        public void ShowCarType()
        {
            Console.Write(Type + " ");
        }
    }

    public class Car
    {
        public string Number { get; set; }
        public CarType CarType { get; set; }

        public Car(string number, CarType carType)
        {
            Number = number;
            CarType = carType;
        }

        public void ShowCar()
        {
            CarType.ShowCarType();
            Console.WriteLine(Number);
        }
    }

    public class CarFactory
    {
        public List<CarType> _CarTypes { get; set; }

        public CarFactory()
        {
            _CarTypes = new List<CarType>();
        }

        public CarType getCarType(string type)
        {
            foreach(CarType carType in _CarTypes)
                if (carType.Type == type) return carType;

            CarType newCarType = new CarType(type);
            _CarTypes.Add(newCarType);
            return newCarType;
        }
    }

    public class Parking
    {
        public CarFactory CarFactory { get; set; }
        public List<Car> Cars { get; set; }

        public Parking()
        {
            CarFactory = new CarFactory();
            Cars = new List<Car>();
        }

        public void addCar(string type, string number)
        {
            Cars.Add(new Car(number, CarFactory.getCarType(type)));
        }

        public void showCars()
        {
            foreach (Car car in Cars)
                car.ShowCar();
        }
    }
}
