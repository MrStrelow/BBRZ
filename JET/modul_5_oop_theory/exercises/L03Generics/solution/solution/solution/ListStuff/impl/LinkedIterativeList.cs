using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace solution;


public class LinkedIterativeList<T> : LinkedList<T>, IEnumerable<T>
{
    public LinkedIterativeList() : base()
    {
    }

    public LinkedIterativeList(IMyList<T> list) : base(list)
    {
    }

    public override T Get(int position)
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

        return current.Data;
    }

    public override void AddEnd(T element)
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

    public override void AddBeginning(T element)
    {
        Node<T> newNode = new Node<T>(element)
        {
            Next = Head
        };

        Head = newNode;
    }

    public override void Update(int position, T element)
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
    }

    public override (T foundElement, int index) Find(T element)
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

    public override void Remove(T element)
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

    public override IEnumerator<T> GetEnumerator()
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
}
