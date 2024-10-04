using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class TennisShoes : Shoes
{
    public TennisShoeProperties TennisShoeProperties { get; set; }

}

enum TennisShoeProperties
{
    Grass, Sand, Hard
}
