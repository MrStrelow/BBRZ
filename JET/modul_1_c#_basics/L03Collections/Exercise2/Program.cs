public class Node
{
    public string Data;
    public Node Next;

    public Node(string data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    private Node head;

    public LinkedList()
    {
        head = null;
    }

    public void Add(string data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}

public class ArrayList
{
    private string[] array;
    private int count;

    public ArrayList(int capacity)
    {
        array = new string[capacity];
        count = 0;
    }

    public void Add(string data)
    {
        if (count == array.Length)
        {
            Resize();
        }
        array[count++] = data;
    }

    private void Resize()
    {
        string[] newArray = new string[array.Length * 2];
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

public class Programm
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        list.Add("Apfel");
        list.Add("Banane");
        list.Add("Kirsche");

        list.PrintList();

        ArrayList arrayList = new ArrayList(2);
        arrayList.Add("Hund");
        arrayList.Add("Katze");
        arrayList.Add("Vogel");

        arrayList.PrintList();

        LinkedList<string> stringList = new LinkedList<string>();
        stringList.Add("Eins");
        stringList.Add("Zwei");
        stringList.Add("Drei");

        stringList.PrintList();

        ArrayList<int> arrayIntList = new ArrayList<int>(3);
        arrayIntList.Add(10);
        arrayIntList.Add(20);
        arrayIntList.Add(30);

        arrayList.PrintList();
    }
}

