using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;


internal interface IFan
{
    public CheeringTool cheeringTool { get; set; }

    public String Cheer();

    //TODO: oberservable pattern
    public String Boo();

}
