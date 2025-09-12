using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1;

struct Struct
{
    public string Name { get; set; }
    public int Age { get; set; }

    public List<object> list { get; set; }

    public Struct(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return "not implemented but its at least defined :)";
    }
}
