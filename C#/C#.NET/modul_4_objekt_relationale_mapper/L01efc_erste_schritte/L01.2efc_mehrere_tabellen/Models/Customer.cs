﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruehstuecksrestaurantMore.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Visit> visits { get; set; }
}
