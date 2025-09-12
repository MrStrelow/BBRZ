using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise1.src.Domain.People.Entities;

namespace Exercise1;
internal class Worker : Human
{
    public string Factory { get; set; }
    public override string ToString()
    {
        return $"{base.ToString()},Pos.:{Factory}";
    }
}
