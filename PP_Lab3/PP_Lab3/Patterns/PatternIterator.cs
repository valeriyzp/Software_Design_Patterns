using System;
using System.Collections.Generic;

namespace PP_Lab3.Patterns
{
    public interface IIterator
    {
        public bool isEnd();
        public int getNext();
        public void setToStart();
    }

    public interface ICollection
    {
        public void Add(int value);
        public int this[int index] { get; set; }
        public int Size();
        public IIterator createFrontIterator();
        public IIterator createBackIterator();
    }

    public class Queue : ICollection
    {
        private List<int> _Array { get; set; }

        public Queue()
        {
            _Array = new List<int>();
        }

        public void Add(int value)
        {
            _Array.Add(value);
        }

        public int this[int index]
        {
            get
            {
                return _Array[index];
            }
            set
            {
                _Array[index] = value;
            }
        }

        public int Size()
        {
            return _Array.Count;
        }

        public IIterator createFrontIterator()
        {
            return new FrontIterator(this);
        }

        public IIterator createBackIterator()
        {
            return new BackIterator(this);
        }
    }

    public class FrontIterator : IIterator
    {
        private ICollection _Collection { get; set; }
        private int _IterationState { get; set; }

        public FrontIterator(ICollection c)
        {
            _Collection = c;
            setToStart();
        }

        public bool isEnd()
        {
            return _IterationState >= _Collection.Size();
        }

        public int getNext()
        {
            if (!isEnd())
                return _Collection[_IterationState++];
            else
                throw new Exception("Iterator has reached the end");
        }

        public void setToStart()
        {
            _IterationState = 0;
        }
    }

    public class BackIterator : IIterator
    {
        private ICollection _Collection { get; set; }
        private int _IterationState { get; set; }

        public BackIterator(ICollection c)
        {
            _Collection = c;
            setToStart();
        }

        public bool isEnd()
        {
            return _IterationState < 0;
        }

        public int getNext()
        {
            if (!isEnd())
                return _Collection[_IterationState--];
            else
                throw new Exception("Iterator has reached the end");
        }

        public void setToStart()
        {
            _IterationState = _Collection.Size() - 1;
        }
    }
}
