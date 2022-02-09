using System;
using System.Collections.Generic;

namespace PP_Lab5.Tasks
{
    public interface IPublisher
    {
        public void Subscribe(ISubscriber subscriber);
        public void UnSubscribe(ISubscriber subscriber);
        public void NotifySubscribers();
    }

    public interface ISubscriber
    {
        public void Update(int time);
    }

    public abstract class Craftsman : ISubscriber
    {
        public string Name { get; set; }

        public Craftsman(string name)
        {
            Name = name;
        }

        public abstract void Update(int time);
    }

    public class Baker : Craftsman
    {
        public Baker(string name) : base(name) { ; }

        public override void Update(int time)
        {
            switch(time)
            {
                case 4:
                    {
                        KindleOven();
                        break;
                    }
                case 5:
                    {
                        KneadDough();
                        break;
                    }
                case 6:
                    {
                        PutDoughToOven();
                        break;
                    }
                case 7:
                    {
                        TakeDoughFromOven();
                        break;
                    }
                case 8:
                    {
                        OpenBakery();
                        break;
                    }
                case 16:
                    {
                        CloseBakery();
                        break;
                    }
            }
        }

        public void KindleOven()
        {
            Console.WriteLine($"{Name} kindle the oven");
        }

        public void KneadDough()
        {
            Console.WriteLine($"{Name} knead the dough");
        }

        public void PutDoughToOven()
        {
            Console.WriteLine($"{Name} put dough to oven");
        }

        public void TakeDoughFromOven()
        {
            Console.WriteLine($"{Name} take out the baking from oven");
        }

        public void OpenBakery()
        {
            Console.WriteLine($"{Name} open bakery for selling baking");
        }

        public void CloseBakery()
        {
            Console.WriteLine($"{Name} close bakery");
        }
    }

    public class Shoemaker : Craftsman
    {
        public Shoemaker(string name) : base(name) { ; }

        public override void Update(int time)
        {
            switch(time)
            {
                case 10:
                    {
                        OpenWorkshop();
                        break;
                    }
                case 11:
                    {
                        DrinkBeer();
                        break;
                    }
                case 15:
                    {
                        StartSing();
                        break;
                    }
                case 18:
                    {
                        CloseWorkshop();
                        break;
                    }
            }
        }

        public void OpenWorkshop()
        {
            Console.WriteLine($"{Name} open workshop");
        }

        public void DrinkBeer()
        {
            Console.WriteLine($"{Name} drink a beer can");
        }

        public void StartSing()
        {
            Console.WriteLine($"{Name} start singing a song");
        }

        public void CloseWorkshop()
        {
            Console.WriteLine($"{Name} close workshop and goes to the ham");
        }
    }

    public class Barkeeper : Craftsman
    {
        public Barkeeper(string name) : base(name) { ; }

        public override void Update(int time)
        {
            switch(time)
            {
                case 16:
                    {
                        BrewBeer();
                        break;
                    }
                case 17:
                    {
                        OpenHam();
                        break;
                    }
                case 23:
                    {
                        CloseHam();
                        break;
                    }
            }
        }

        public void BrewBeer()
        {
            Console.WriteLine($"{Name} start brewing beer");
        }

        public void OpenHam()
        {
            Console.WriteLine($"{Name} open the ham");
        }

        public void CloseHam()
        {
            Console.WriteLine($"{Name} close the ham");
        }
    }

    public interface IIterator
    {
        public bool IsEnd();
        public ISubscriber GetNext();
        public void Update();
    }

    public interface ICollection
    {
        public void Add(ISubscriber subscriber);
        public void Remove(ISubscriber subscriber);
        public ISubscriber this[int index] { get; set; }
        public int Size();
        public IIterator CreateIterator();
    }

    public class CraftsmanList : ICollection
    {
        private List<ISubscriber> _Subscribers { get; set; }

        public CraftsmanList()
        {
            _Subscribers = new List<ISubscriber>();
        }

        public void Add(ISubscriber subscriber)
        {
            if (!_Subscribers.Contains(subscriber))
                _Subscribers.Add(subscriber);
        }

        public void Remove(ISubscriber subscriber)
        {
            if (_Subscribers.Contains(subscriber))
                _Subscribers.Remove(subscriber);
        }

        public ISubscriber this[int index]
        {
            get
            {
                return _Subscribers[index];
            }
            set
            {
                _Subscribers[index] = value;
            }
        }

        public int Size()
        {
            return _Subscribers.Count;
        }

        public IIterator CreateIterator()
        {
            return new Iterator(this);
        }
    }

    public class Iterator : IIterator
    {
        private ICollection _Collection { get; set; }
        private int _IterationState { get; set; }

        public Iterator(ICollection collection)
        {
            _Collection = collection;
            Update();
        }

        public bool IsEnd()
        {
            if (_IterationState >= _Collection.Size())
                return true;
            else
                return false;
        }

        public ISubscriber GetNext()
        {
            if (!IsEnd())
                return _Collection[_IterationState++];
            else
                throw new Exception("Iterator reach the end...");
        }

        public void Update()
        {
            _IterationState = 0;
        }
    }

    public class Clock : IPublisher
    {
        private static Clock _Clock { get; set; }
        private CraftsmanList _Craftsmans { get; set; }
        public int Time { get; set; }

        private Clock()
        {
            _Craftsmans = new CraftsmanList();
            Time = 0;
        }

        public static Clock GetInstance()
        {
            if (_Clock == null)
                _Clock = new Clock();

            return _Clock;
        }

        public void NextHour()
        {
            Time = Time == 23 ?  0 : ++Time;

            Console.WriteLine($"Current time: {Time}:00");
            NotifySubscribers();
        }

        public void SimulateAllDay()
        {
            Time = 23;

            Console.WriteLine("All day simulation: ");
            for (int i = 0; i < 24; ++i)
                NextHour();
        }

        public void Subscribe(ISubscriber subscriber)
        {
            _Craftsmans.Add(subscriber);
        }

        public void UnSubscribe(ISubscriber subscriber)
        {
            _Craftsmans.Remove(subscriber);
        }

        public void NotifySubscribers()
        {
            IIterator Iterator = _Craftsmans.CreateIterator();
            
            while(!Iterator.IsEnd())
            {
                Iterator.GetNext().Update(Time);
            }
        }
    }
}
