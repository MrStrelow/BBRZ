using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise1;

public abstract class LinkedList<T> : IMyList<T>
{
    protected Node<T>? Head { get; set; }

    public LinkedList()
    {
        Head = null;
    }

    public LinkedList(IMyList<T> list)
    {
        foreach (var element in list)
        {
            AddEnd(element);
        }
    }

    public abstract T Get(int position);
    public abstract void Add(T element, int position);
    public abstract void AddEnd(T element);
    public abstract void AddBeginning(T element);
    public abstract void Update(T element, int position);
    public abstract (T foundElement, int index) Find(T element);
    public abstract void Remove(T element);
    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        string output = string.Empty;
        var oldHead = Head;

        while (Head is not null)
        {
            output += $"{Head.ToString()}, ";
            Head = Head.Next;
        }

        Head = oldHead;

        return $"[{output.Substring(0, output.Length - 2)}]";
    }

    public int Length()
    {
        int length = 0;

        var oldHead = Head;

        while (Head is not null)
        {
            length++;
            Head = Head.Next;
        }

        Head = oldHead;

        return length;
    }
}
