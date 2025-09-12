using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;
internal class Manager : Human
{
    public string Department { get; set; }
    public override string ToString()
    {
        return $"{base.ToString()}-Dep.:{Department}";
    }
}
