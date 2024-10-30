using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise2;

public class LinkedRecursiveList<T> : LinkedList<T>, IEnumerable<T>
{
    public LinkedRecursiveList() : base()
    {
    }

    public LinkedRecursiveList(IFixedCapacityList<T> list) : base(list)
    {
    }

    public override T Get(int position)
    {
        return GetNode(position).Data;
    }

    public override void AddEnd(T element)
    {
        Head = AddEndRecursive(Head, element);
    }

    private Node<T> AddEndRecursive(Node<T>? node, T element)
    {
        if (node == null)
            return new Node<T>(element);

        node.Next = AddEndRecursive(node.Next, element);
        return node;
    }

    public override void AddBeginning(T element)
    {
        Head = new Node<T>(element)
        {
            Next = Head
        };
    }

    public override void Update(T element, int position)
    {
        UpdateRecursive(Head, position, element);
    }

    private void UpdateRecursive(Node<T>? node, int position, T element)
    {
        if (node == null)
            throw new ArgumentOutOfRangeException();

        if (position == 0)
        {
            node.Data = element;
            return;
        }

        UpdateRecursive(node.Next, position - 1, element);
    }

    public override (T foundElement, int index) Find(T element)
    {
        int index = 0;
        return FindRecursive(Head, element, index);
    }

    private (T foundElement, int index) FindRecursive(Node<T>? node, T element, int index)
    {
        if (node == null)
            throw new InvalidOperationException("Element not found");

        if (node.Data.Equals(element))
            return (node.Data, index);

        index++;

        return FindRecursive(node.Next, element, index);
    }

    public override void Remove(T element)
    {
        Head = RemoveRecursive(Head, element);
    }

    private Node<T>? RemoveRecursive(Node<T>? node, T element)
    {
        if (node == null)
            throw new InvalidOperationException("Element not found");

        if (node.Data.Equals(element))
            return node.Next;

        node.Next = RemoveRecursive(node.Next, element);
        return node;
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

    public override void Add(T element, int position)
    {
        Node<T> newNode = new Node<T>(element);

        if (position == 0)
        {
            newNode.Next = Head;
            Head = newNode;
        }
        else
        {
            var previous = GetNode(position - 1);
            var current = previous.Next;

            previous.Next = newNode;
            newNode.Next = current;
        }
    }

    private Node<T> GetNode(int position)
    {
        return GetNodeRecursive(Head, position);
    }

    private Node<T> GetNodeRecursive(Node<T>? node, int position)
    {
        if (node is null)
            throw new ArgumentOutOfRangeException();

        if (position == 0)
            return node;

        return GetNodeRecursive(node.Next, position - 1);
    }
}
