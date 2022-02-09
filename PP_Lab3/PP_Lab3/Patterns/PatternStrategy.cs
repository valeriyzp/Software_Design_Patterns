using System;
using System.Collections.Generic;

namespace PP_Lab3.Patterns
{
    public interface IStrategy
    {
        public void Sort<T>(List<T> arr, int size) where T : IComparable;
    }

    public class BubbleSort : IStrategy
    {
        public BubbleSort() { ;}

        public void Sort<T>(List<T> arr, int size) where T : IComparable
        {
            for(int i = 0; i < size; ++i)
                for(int j = size - 1; j > i; --j)
                {
                    if(arr[j].CompareTo(arr[j - 1]) < 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
        }
    }

    public class ReverseBubbleSort : IStrategy
    {
        public ReverseBubbleSort() {; }

        public void Sort<T>(List<T> arr, int size) where T : IComparable
        {
            for (int i = 0; i < size; ++i)
                for (int j = size - 1; j > i; --j)
                {
                    if (arr[j].CompareTo(arr[j - 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
        }
    }

    public class NewVector<T> where T : IComparable
    {
        private List<T> Array { get; set; }
        private IStrategy Strategy { get; set; }

        public NewVector(IStrategy strategy)
        {
            Array = new List<T>();
            Strategy = strategy;
        }

        public void Sort()
        {
            Strategy.Sort(Array, Array.Count);
        }

        public int Size()
        {
            return Array.Count;
        }

        public T this[int index]
        {
            get
            {
                return Array[index];
            }
            set
            {
                Array[index] = value;
            }
        }

        public void Add(T value)
        {
            Array.Add(value);
        }

        public void SetStrategy(IStrategy strategy)
        {
            Strategy = strategy;
        }
    }
}
