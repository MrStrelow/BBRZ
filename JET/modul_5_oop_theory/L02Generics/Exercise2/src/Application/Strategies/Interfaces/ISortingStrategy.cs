using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;

public interface ISortingStrategy<T> where T : IComparable<T>
{
    void Sort(ISortedList<T> list);
}
