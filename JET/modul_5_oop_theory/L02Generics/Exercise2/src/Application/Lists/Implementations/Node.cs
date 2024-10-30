using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;
public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }

    public override string ToString()
    {
        return Data is not null ? Data.ToString() : "null";
    }
}
