using System;
using System.Collections.Generic;

namespace PP_Lab3.Patterns
{
    public interface IPublisher
    {
        public void Subscribe(ISubscriber subscriber);
        public void UnSubscribe(ISubscriber subscriber);
        public void NotifySubscribers();
    }

    public interface ISubscriber
    {
        public void Update(string message);
    }

    public class Store : IPublisher
    {
        private List<ISubscriber> _Subscribers { get; set; }

        public Store()
        {
            _Subscribers = new List<ISubscriber>();
        }

        public void Subscribe(ISubscriber subscriber)
        {
            if(!_Subscribers.Contains(subscriber))
                _Subscribers.Add(subscriber);
        }

        public void UnSubscribe(ISubscriber subscriber)
        {
            if (_Subscribers.Contains(subscriber))
                _Subscribers.Remove(subscriber);
        }

        public void NotifySubscribers()
        {
            foreach (ISubscriber subscriber in _Subscribers)
                subscriber.Update("The store has a brand new IPhone 9!");
        }
    }

    public class Man : ISubscriber
    {
        public string Name { get; set; }

        public Man(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"Man {Name} received message: {message}");
        }
    }

    public class Woman : ISubscriber
    {
        public string Name { get; set; }

        public Woman(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"Woman {Name} received message: {message}");
        }
    }
}
