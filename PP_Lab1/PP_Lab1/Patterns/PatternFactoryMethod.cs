namespace PP_Lab1.Patterns
{
    public interface ITransport
    {
        public string GetInformation();
    }

    public class Car : ITransport
    {
        public string GetInformation()
        {
            return "Current transport is car";
        }
    }

    public class Ship : ITransport
    {
        public string GetInformation()
        {
            return "Current transport is ship";
        }
    }

    public interface ITransportFactory
    {
        ITransport Create();
    }

    public class CarFactory : ITransportFactory
    {
        public ITransport Create()
        {
            return new Car();
        }
    }

    public class ShipFactory : ITransportFactory
    {
        public ITransport Create()
        {
            return new Ship();
        }
    }
}
