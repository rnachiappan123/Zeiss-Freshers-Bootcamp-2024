using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArrayProblem
{
    public class DynamicArray<TArrayType> : IEnumerable<TArrayType>
    {
        private TArrayType[] array;
        private int capacity;
        public DynamicArray(int size)
        {
            this.capacity = size;
            array = new TArrayType[size];
        }
        private int count = 0;
        public int Count { get { return count; } }
        public void Add(int index, TArrayType value)
        {
            CheckCapacity(count + 1);
            array[count++] = value;
        }
        private void CheckCapacity(int requiredCapacity)
        {
            if (capacity < requiredCapacity)
            {
                Array.Resize(ref array, (int)(capacity * 2));
                capacity *= 2;
            }
        }
        public TArrayType this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException($"index {index} not found");
                }
                return array[index];
            }
        }
        public IEnumerator<TArrayType> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
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