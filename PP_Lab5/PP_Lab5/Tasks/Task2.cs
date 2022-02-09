using System;
using System.Collections.Generic;

namespace PP_Lab5.Tasks
{
    public interface IEdibleGift
    {
        public string ShowEdibleGift();
    }

    public interface IInedibleGift
    {
        public string ShowInedibleGift();
    }

    public interface IGiftFactory
    {
        public IEdibleGift CreateEdibleGift();
        public IInedibleGift CreateInedibleGift();
    }

    public class GoodEdibleGift : IEdibleGift
    {
        public GoodEdibleGift() { ; }

        public string ShowEdibleGift()
        {
            return "sweets";
        }
    }

    public class BadEdibleGift : IEdibleGift
    {
        public BadEdibleGift() {; }

        public string ShowEdibleGift()
        {
            return "bitter pills";
        }
    }

    public class GoodInedibleGift : IInedibleGift
    {
        public GoodInedibleGift() { ; }

        public string ShowInedibleGift()
        {
            return "toys";
        }
    }

    public class BadInedibleGift : IInedibleGift
    {
        public BadInedibleGift() {; }

        public string ShowInedibleGift()
        {
            return "cutting";
        }
    }

    public class GoodGiftFactory : IGiftFactory
    {
        public GoodGiftFactory() { ; }

        public IEdibleGift CreateEdibleGift()
        {
            return new GoodEdibleGift();
        }

        public IInedibleGift CreateInedibleGift()
        {
            return new GoodInedibleGift();
        }
    }

    public class BadGiftFactory : IGiftFactory
    {
        public BadGiftFactory() {; }

        public IEdibleGift CreateEdibleGift()
        {
            return new BadEdibleGift();
        }

        public IInedibleGift CreateInedibleGift()
        {
            return new BadInedibleGift();
        }
    }

    public class Gift
    {
        public IEdibleGift EdibleGift { get; set; }
        public IInedibleGift InedibleGift { get; set; }

        public Gift(IGiftFactory GiftFactory)
        {
            EdibleGift = GiftFactory.CreateEdibleGift();
            InedibleGift = GiftFactory.CreateInedibleGift();
        }

        public void ShowGift()
        {
            Console.WriteLine($"{EdibleGift.ShowEdibleGift()} and {InedibleGift.ShowInedibleGift()}");
        }
    }

    public class Child
    {
        public string Name { get; set; }

        public Child(string name)
        {
            Name = name;
        }

        public void SendGift(Gift gift)
        {
            Console.Write($"{Name} received a gift: ");
            gift.ShowGift();
        }

        public void SendLetter(Nicholas SaintNicholas, int good, int bad)
        {
            SaintNicholas.SendLetter(this, good, bad);
        }
    }

    public interface IChildAndFactoryListIterator
    {
        public bool IsEnd();
        public Tuple<Child, IGiftFactory> GetNext();
        public void Update();
    }

    public interface IChildAndFactoryList
    {
        public void Add(Child child, IGiftFactory giftFactory);
        public void Remove(Child child);
        public Tuple<Child, IGiftFactory> this[int index] { get; set; }
        public int Size();
        public ChildAndFactoryListIterator CreateIterator();
    }

    public class ChildAndFactoryList : IChildAndFactoryList
    {
        private List<Child> Child { get; set; }
        private List<IGiftFactory> GiftFactory { get; set; }

        public ChildAndFactoryList()
        {
            Child = new List<Child>();
            GiftFactory = new List<IGiftFactory>();
        }

        public void Add(Child child, IGiftFactory giftFactory)
        {
            if (Child.Contains(child))
            {
                GiftFactory[Child.IndexOf(child)] = giftFactory;
            }
            else
            {
                Child.Add(child);
                GiftFactory.Add(giftFactory);
            }
        }

        public void Remove(Child child)
        {
            if (Child.Contains(child))
            {
                GiftFactory.RemoveAt(Child.IndexOf(child));
                Child.Remove(child);
            }
        }

        public Tuple<Child, IGiftFactory> this[int index]
        {
            get
            {
                return new Tuple<Child, IGiftFactory>(Child[index], GiftFactory[index]);
            }
            set
            {
                Child[index] = value.Item1;
                GiftFactory[index] = value.Item2;
            }
        }

        public int Size()
        {
            return Child.Count;
        }

        public ChildAndFactoryListIterator CreateIterator()
        {
            return new ChildAndFactoryListIterator(this);
        }
    }

    public class ChildAndFactoryListIterator : IChildAndFactoryListIterator
    {
        private IChildAndFactoryList _Collection { get; set; }
        private int _IterationState { get; set; }

        public ChildAndFactoryListIterator(IChildAndFactoryList collection)
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

        public Tuple<Child, IGiftFactory> GetNext()
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

    public class Nicholas
    {
        private static Nicholas _Nicholas { get; set; }
        private IGiftFactory _GoodGiftFactory { get; set; }
        private IGiftFactory _BadGiftFactory { get; set; }
        private ChildAndFactoryList _ChildAndFactoryList { get; set; }

        private Nicholas()
        {
            _GoodGiftFactory = new GoodGiftFactory();
            _BadGiftFactory = new BadGiftFactory();
            _ChildAndFactoryList = new ChildAndFactoryList();
        }

        public static Nicholas GetInstance()
        {
            if (_Nicholas == null)
            {
                _Nicholas = new Nicholas();
                return _Nicholas;
            }
            else
                return _Nicholas;
        }

        public void SendLetter(Child child, int good, int bad)
        {
            if (good > bad)
                _ChildAndFactoryList.Add(child, _GoodGiftFactory);
            else
                _ChildAndFactoryList.Add(child, _BadGiftFactory);
        }

        public void CelebrateSaintNicholasDay()
        {
            Console.WriteLine("Celebrate Saint Nicholas day: ");

            IChildAndFactoryListIterator Iterator = _ChildAndFactoryList.CreateIterator();

            while (!Iterator.IsEnd())
            {
                Tuple<Child, IGiftFactory> ChildAndFactory = Iterator.GetNext();
                ChildAndFactory.Item1.SendGift(new Gift(ChildAndFactory.Item2));
            }

            _ChildAndFactoryList = new ChildAndFactoryList();
        }
    }
}
