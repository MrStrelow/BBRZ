﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1;

// Der Name schlägt vor, dass keine Methoden zu verfügung gestellt werden, welche die Liste erweitern.
// Das wäre in unserem Fall verschiedenste Add Methoden (wie AddFirst(), AddLast(), Add(int position)
public interface IMyList<T> : IEnumerable<T>
{
    T Get(int position);
    void Update(T element, int position);
    (T foundElement, int index) Find(T element);
    void Remove(T element);
    void Add(T element, int position);
    void AddEnd(T element);
    void AddBeginning(T element);
    int Length();

    // TODO: Frage: Hier ein ToString? ist ein ToString für alle listen gleich?
}
