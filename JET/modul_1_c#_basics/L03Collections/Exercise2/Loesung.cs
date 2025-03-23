public class Node<T>
{
    public T Data;
    public Node<T> Next;

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T>
{
    private Node<T> head;

    public LinkedList()
    {
        head = null;
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public T Find(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return current.Data;
            current = current.Next;
        }
        return default;
    }

    public void Remove(T data)
    {
        if (head == null) return;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            return;
        }

        Node<T> current = head;
        while (current.Next != null)
        {
            if (current.Next.Data.Equals(data))
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public void PrintList()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}


public class ArrayList<T>
{
    private T[] array;
    private int count;

    public ArrayList(int capacity)
    {
        array = new T[capacity];
        count = 0;
    }

    public void Add(T data)
    {
        if (count == array.Length)
        {
            Resize();
        }
        array[count++] = data;
    }

    public T Find(T data)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i].Equals(data))
                return array[i];
        }
        return default;
    }

    public void Remove(T data)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i].Equals(data))
            {
                for (int j = i; j < count - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                count--;
                return;
            }
        }
    }

    private void Resize()
    {
        T[] newArray = new T[array.Length * 2];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        array = newArray;
    }

    public void PrintList()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // LinkedList Beispiel
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.Add("Apfel");
        linkedList.Add("Banane");
        linkedList.Add("Kirsche");

        Console.WriteLine("LinkedList vor Entfernen:");
        linkedList.PrintList();

        linkedList.Remove("Banane");

        Console.WriteLine("LinkedList nach Entfernen:");
        linkedList.PrintList();

        Console.WriteLine("Gefundenes Element: " + linkedList.Find("Kirsche"));

        // ArrayList Beispiel
        ArrayList<int> arrayList = new ArrayList<int>(2);
        arrayList.Add(10);
        arrayList.Add(20);
        arrayList.Add(30);

        Console.WriteLine("ArrayList vor Entfernen:");
        arrayList.PrintList();

        arrayList.Remove(20);

        Console.WriteLine("ArrayList nach Entfernen:");
        arrayList.PrintList();

        Console.WriteLine("Gefundenes Element: " + arrayList.Find(30));
    }
}