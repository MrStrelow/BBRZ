using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class GermanFan : Human, IFan
{
    public CheeringTool cheeringTool { get; set; }

    private string cheer = "das hätte noch besser gehen können.";
    private string boo = "nein.";

    public GermanFan(PersonalInformation data, Authentication id) : base(data, id)
    {
    }

    public string Cheer()
    {
        Console.WriteLine(cheer + $" - verwendet: {cheeringTool.UseMe()}");
        return cheer;
    }

    public string Boo()
    {
        Console.WriteLine(boo);
        return boo;
    }
}
