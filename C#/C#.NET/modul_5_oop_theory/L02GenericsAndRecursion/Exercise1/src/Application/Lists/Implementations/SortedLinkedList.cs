using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1;

// TODO: auf IEnumerable eingehen (ist in IMyList). Das erlaubt uns die liste in forEach und LINQ zu verwenden!

// Achtung! Bei einer sortierten Liste macht ein AddBeginning und AddEnd keinen Sinn.
// Wir werden diese Methoden einfach als Add verwenden. Streng genommen verletzen wir hier das Ersetzbarkeitsprinzip! 
// Wir werden in weiteren Exercises dieses Problem beheben. 
public class SortedLinkedList<T> : LinkedIterativeList<T> where T : IComparable<T>
{
    public bool Ascending { get; set; }

    public SortedLinkedList(bool ascending)
    {
        Ascending = ascending;
    }

    public override void Add(T element, int position)
    {
        base.Add(element, position);
        BubbleSort();
    }

    public override void AddBeginning(T element)
    {
        base.AddBeginning(element);
        BubbleSort();
    }

    public override void AddEnd(T element)
    {
        base.AddEnd(element);
        BubbleSort();
    }

    public override (T foundElement, int index) Find(T element)
    {
        return base.Find(element);
    }

    public override T Get(int position)
    {
        return base.Get(position);
    }

    public override IEnumerator<T> GetEnumerator()
    {
        return base.GetEnumerator();
    }

    public override void Remove(T element)
    {
        base.Remove(element);
    }

    public override void Update(T element, int position)
    {
        base.Update(element, position);
        BubbleSort();
    }

    private void BubbleSort()
    {
        // early exit if not swapped.
        // we can do this because of the assumption that the list is already sortet
        // before a write operation (add and update)
        bool swapped;
        bool Compare(T a, T b) => Ascending ? a.CompareTo(b) > 0 : a.CompareTo(b) < 0;

        do
        {
            swapped = false;
            Node<T>? current = Head;
            while (current?.Next != null)
            {
                if (Compare(current.Data, current.Next.Data))
                {
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }
}