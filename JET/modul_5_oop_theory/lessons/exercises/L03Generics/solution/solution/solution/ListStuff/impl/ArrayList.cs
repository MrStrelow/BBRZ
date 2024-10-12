using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace solution;

public class ArrayList<T> : IMyList<T>
{
    private T[] _array;
    private int _currentSize;
    private int _capacity;

    public ArrayList(int capacity = 10)
    {
        _capacity = capacity;
        _array = new T[_capacity];
        _currentSize = 0;
    }

    public T Get(int position)
    {
        if (position < 0 || position >= _currentSize)
            throw new ArgumentOutOfRangeException();

        return _array[position];
    }

    public void AddEnd(T element)
    {
        EnsureCapacity();
        _array[_currentSize] = element;
        _currentSize++;
    }

    public void AddBeginning(T element)
    {
        EnsureCapacity();

        for (int i = _currentSize; i > 0; i--)
        {
            _array[i] = _array[i - 1];
        }

        _array[0] = element;
        _currentSize++;
    }

    public void Update(int position, T element)
    {
        if (position < 0 || position >= _currentSize)
            throw new ArgumentOutOfRangeException();

        _array[position] = element;
    }

    public (T foundElement, int index) Find(T element)
    {
        for (int i = 0; i < _currentSize; i++)
        {
            if (_array[i].Equals(element))
                return (_array[i], i);
        }

        throw new InvalidOperationException("Element not found");
    }

    public void Remove(T element)
    {
        (_, int i) = Find(element);

        for (; i < _currentSize - 1; i++)
        {
            _array[i] = _array[i + 1];
        }

        _currentSize--;
    }

    private void EnsureCapacity()
    {
        if (_currentSize == _capacity)
        {
            _capacity = (int)(_capacity * 1.2);
            T[] newArray = new T[_capacity];
            Array.Copy(_array, newArray, _currentSize);
            _array = newArray;
        }
    }

    public override string ToString()
    {
        // return $"[{string.Join(",", _array)}]";                          // without null checks
        // return $"[{string.Join(",", _array.Where(x => x != null))}]";    // Stream API/functinoal style
        // return Regex.Replace($"[{string.Join(",", _array)}]", ",+", ""); // Regex
        return _array
            .Where(x => x != null) // "map" is select and "filter" is where
            .Aggregate("[", (current, next) => current + (current == "[" ? "" : ", ") + next) + "]"; // "reduce"

    }

    // with iterative programming.
    //public override string ToString()
    //{
    //    var sb = new StringBuilder("[");
    //    bool firstElement = true;

    //    foreach (var item in _array)
    //    {
    //        if (item is not null)
    //        {
    //            if (!firstElement)
    //            {
    //                sb.Append(",");
    //            }

    //            sb.Append(item);

    //            firstElement = false;
    //        }
    //    }

    //    sb.Append("]");
    //    return sb.ToString();
    //}


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _currentSize; i++)
        {
            yield return _array[i];
        }
    }
}
