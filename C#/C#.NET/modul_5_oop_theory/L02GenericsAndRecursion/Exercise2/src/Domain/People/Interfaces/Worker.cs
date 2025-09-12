using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;
internal class Worker : Human
{
    public string Factory { get; set; }
    public override string ToString()
    {
        return $"{base.ToString()},Pos.:{Factory}";
    }
}
