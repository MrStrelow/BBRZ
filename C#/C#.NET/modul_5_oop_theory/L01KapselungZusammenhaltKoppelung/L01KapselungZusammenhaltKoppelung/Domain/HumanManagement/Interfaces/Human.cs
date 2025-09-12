using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

abstract class Human
{
    public PersonalInformation Data { get; set; }
    public Authentication Id { get; set; }

    public Human(PersonalInformation data, Authentication id)
    {
        Data = data;
        Id = id;
    }

 }
