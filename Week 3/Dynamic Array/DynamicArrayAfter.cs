using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArrayProblem
{
    public class DynamicArray<TArrayType> : IEnumerable<TArrayType>
    {
        private TArrayType[] array;
        private uint capacity;
        public DynamicArray(uint size)
        {
            this.capacity = size;
            array = new TArrayType[size];
        }
        private uint count = 0;
        public uint Count { get { return count; } }
        public void Add(uint index, TArrayType value)
        {
            CheckCapacity(index + 1);
            array[index] = value;
            count++;
        }
        private void CheckCapacity(uint requiredCapacity)
        {
            if (capacity < requiredCapacity)
            {
                Array.Resize(ref array, (int)(requiredCapacity * 2));
                capacity = requiredCapacity * 2;
            }
        }
        public TArrayType this[uint index]
        {
            get
            {
                if (index >= capacity)
                {
                    throw new ArgumentOutOfRangeException($"index {index} not found");
                }
                return array[index];
            }
        }
        public IEnumerator<TArrayType> GetEnumerator()
        {
            for (uint i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Program
    {
        static void Main()
        {
            DynamicArray<int> numbers = new DynamicArray<int>(2);
            numbers.Add(0, 100);
            numbers.Add(1, 200);
            numbers.Add(2, 300);
            numbers.Add(3, 400);
            int value = numbers[2];
            System.Console.WriteLine($"Total Number Of Items in Array: {numbers.Count}, Value: {value} at index: 2");

            DynamicArray<string> stringItems = new DynamicArray<string>(2);
            stringItems.Add(0, "100");
            stringItems.Add(1, "200");
            stringItems.Add(2, "300");
            stringItems.Add(3, "400");
            string itemValue = stringItems[3];
            System.Console.WriteLine($"Total Number Of Items in Array: {stringItems.Count}, Value: {itemValue} at index: 3");
        }
    }
}