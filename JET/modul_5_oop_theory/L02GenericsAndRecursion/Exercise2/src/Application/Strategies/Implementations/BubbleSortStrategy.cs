using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;

public class BubbleSortStrategy<T> : ISortingStrategy<T> where T : IComparable<T>
{
    public void Sort(ISortedList<T> list)
    {
        bool swapped;
        int n = list.Length();

        do
        {
            swapped = false;
            for (int i = 0; i < n-1; i++)
            {
                var current = list.Get(i);
                var next = list.Get(i + 1);

                if (current.CompareTo(next) > 0)
                {
                    list.Update(next, i);
                    list.Update(current, i + 1);
                    swapped = true;
                }
            }
            n--; 
        } while (swapped);
    }
}
