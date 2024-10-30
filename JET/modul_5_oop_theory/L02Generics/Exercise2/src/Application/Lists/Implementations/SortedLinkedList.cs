using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;

public class SortedLinkedList<T> : ISortedList<T> where T : IComparable<T>
{
    private readonly ISortingStrategy<T> _sortingStrategy;
    public bool Ascending { get; set; }
    protected Node<T>? Head { get; set; }
        
    public SortedLinkedList(bool ascending)
    {
        Ascending = ascending;
        Head = null;
    }

    public SortedLinkedList(IFixedCapacityList<T> list)
    {
        foreach (var element in list)
        {
            UnsortedAdd(element); // Add is expensive, therefore we call UnsortedAdd.
        }

        Sort(); // And sort afterwards
    }

    public T Get(int position)
    {
        return GetNode(position).Data;
    }

    private void UnsortedAdd(T element)
    {
        if (Head == null)
        {
            Head = new Node<T>(element);
        }
        else
        {
            Node<T>? current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>(element);
        }
    }

    public void Add(T element)
    {
        UnsortedAdd(element);
        Sort();
    }

    public void Update(T element, int position)
    {
        Node<T>? current = Head;
        int index = 0;

        while (current != null && index < position)
        {
            current = current.Next;
            index++;
        }

        if (current == null)
            throw new ArgumentOutOfRangeException();

        current.Data = element;

        Sort();
    }

    public (T foundElement, int index) Find(T element)
    {
        Node<T>? current = Head;
        int index = 0;

        while (current != null)
        {
            if (current.Data.Equals(element))
            {
                return (current.Data, index);
            }

            index++;
            current = current.Next;
        }

        throw new InvalidOperationException("Element not found");

    }

    public void Remove(T element)
    {
        if (Head == null)
            throw new InvalidOperationException("List is empty");

        if (Head.Data.Equals(element))
        {
            Head = Head.Next;
            return;
        }

        Node<T>? current = Head;
        while (current.Next != null && !current.Next.Data.Equals(element))
        {
            current = current.Next;
        }

        if (current.Next == null)
            throw new InvalidOperationException("Element not found");

        current.Next = current.Next.Next;
    }

    private Node<T> GetNode(int position)
    {
        Node<T>? current = Head;
        int index = 0;

        while (current != null && index < position)
        {
            current = current.Next;
            index++;
        }

        if (current == null)
            throw new ArgumentOutOfRangeException();

        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = Head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Length()
    {
        int length = 0;

        while (Head != null)
        {
            length++;
        }

        return length;
    }

    void ISortedList<T>.Sort()
    {
        throw new NotImplementedException();
    }
}