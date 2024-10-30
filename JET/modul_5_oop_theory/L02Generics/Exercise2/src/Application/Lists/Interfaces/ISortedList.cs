
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;
public interface ISortedList<T> : IFixedCapacityList<T> where T : IComparable<T>
{
    void Add(T element);
    protected void Sort();
}