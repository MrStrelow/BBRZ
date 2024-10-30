using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;

public interface IUnsortedList<T> : IFixedCapacityList<T>
{
    void AddEnd(T element);
    void AddBeginning(T element);
    void Add(T element, int position);
}

