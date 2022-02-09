using System;
using System.Collections.Generic;

namespace PP_Lab3.Patterns
{
    public interface IMediator
    {
        public void Notify(Component component, string message);
    }

    public abstract class Component
    {
        protected IMediator _Mediator { get; set; }

        public Component(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public void Notify(string message)
        {
            _Mediator.Notify(this, message);
        }
    }

    public class Plane : Component
    {
        public string Name { get; set; }

        public Plane(string name, IMediator mediator) : base(mediator)
        {
            Name = name;
        }

        public void TryToLanding()
        {
            Notify($"Bort {Name} request landing permission");
        }

        public void AcceptLanding()
        {
            Console.WriteLine($"Bort {Name} landed successfully");
        }

        public void SetInformation(string message)
        {
            Console.WriteLine("Bort {0} get message : {1}", Name, message);
        }
    }

    public class Airport : Component
    {
        public string Name { get; set; }
        public bool isEmptyRunway { get; set; }

        public Airport(string name, IMediator mediator) : base(mediator)
        {
            Name = name;
            isEmptyRunway = true;
        }

        public void EmptyRunway()
        {
            isEmptyRunway = true;
            Notify("Runway is empty now");
        }

        public void NotEmptyRunway()
        {
            isEmptyRunway = false;
            Notify("Runway is not empty now");
        }

        public void SetInformation(string message)
        {
            Console.WriteLine("Airport {0} get message : {1}", Name, message);
        }
    }

    public class Dispatcher : IMediator
    {
        public List<Plane> Planes { get; set; }
        public Airport DispatcherAirport { get; set; }

        public Dispatcher()
        {
            Planes = new List<Plane>();
        }

        public void Notify(Component component, string message)
        {
            if(component == DispatcherAirport)
            {
                foreach (Plane plane in Planes)
                    plane.SetInformation(message);
            }
            else
            {
                DispatcherAirport.SetInformation(message);
                if(DispatcherAirport.isEmptyRunway)
                {
                    ((Plane)component).SetInformation("Landing allowed");
                    ((Plane)component).AcceptLanding();
                }
                else
                {
                    ((Plane)component).SetInformation("Landing denied");
                }
            }
        }
    }
}
