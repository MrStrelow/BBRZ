using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamster;

public interface IRenderer
{
    public int TimeToSleepMs { get; set; }
    void Render();
}
