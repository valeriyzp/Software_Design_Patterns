using System;

namespace PP_Lab3.Patterns
{
    public interface IVisitor
    {
        public void Show(Car car);
        public void Show(Airplane airplane);
    }

    public interface IElement
    {
        public void accept(IVisitor visitor);
    }

    public class Car : IElement
    {
        public string Name { get; set; }

        public Car(string name)
        {
            Name = name;
        }

        public void accept(IVisitor visitor)
        {
            visitor.Show(this);
        }
    }

    public class Airplane : IElement
    {
        public string Name { get; set; }

        public Airplane(string name)
        {
            Name = name;
        }

        public void accept(IVisitor visitor)
        {
            visitor.Show(this);
        }
    }

    public class Traveller : IVisitor
    {
        public Traveller() { ;}
        public void Show(Car car)
        {
            Console.WriteLine("I will ride by car: {0}", car.Name);
        }
        public void Show(Airplane airplane)
        {
            Console.WriteLine("I will fly by airplane: {0}", airplane.Name);
        }
    }
}
