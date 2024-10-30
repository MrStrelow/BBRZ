using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1;
internal abstract class Human : IComparable<Human>
{
    public int Age { get; set; }
    public string Name { get; set; }


    public int CompareTo(Human? other)
    {
        if (other == null)
        {
            return 1;
        }
        else
        {
            return Age.CompareTo(other.Age);
        }
    }

    public override string ToString()
    {
        return $"Name:{Name}-Age:{Age}";
    }
}
