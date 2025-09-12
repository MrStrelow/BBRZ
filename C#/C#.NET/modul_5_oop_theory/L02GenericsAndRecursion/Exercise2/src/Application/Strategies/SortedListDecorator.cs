using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;

public class SortedLinkedListDecorator<T> : IEnumerable<T>
{
    private readonly LinkedList<T> _list;
    private readonly ISortingStrategy<T> _sortingStrategy;

    public SortedLinkedListDecorator(LinkedList<T> list, ISortingStrategy<T> sortingStrategy)
    {
        _list = list;
        _sortingStrategy = sortingStrategy;
    }

    public void Sort() => _sortingStrategy.Sort(_list);

    // Additional methods to delegate list operations and keep sorting as needed
}