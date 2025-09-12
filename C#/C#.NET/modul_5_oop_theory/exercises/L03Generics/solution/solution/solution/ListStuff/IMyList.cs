using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution;

public interface IMyList<T> : IEnumerable<T>
{
    T Get(int position);
    void AddEnd(T element);
    void AddBeginning(T element);
    void Update(int position, T element);
    (T foundElement, int index) Find(T element);
    void Remove(T element);
}
