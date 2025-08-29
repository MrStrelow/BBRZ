//public bool beinhaltet(List<Kunden> kunden, string filterart, int? älterAls = null, int? grenzePunkte = null) {
//    bool ret = false;

//    if (string filterart == "istälteralsX" && älterAls.hasValue) {
//            for (Kunde kunde in kunden)
//        {
//            if (kunde.Alter > älterAls)
//            {
//                ret = true;
//                break;
//            }
//        }
//    }
//        else if (string filterart == "istpunktealsX" && grenzePunkte.hasValue) 
//        {
//            for (Kunde kunde in kunden)
//        {
//            if (kunde.Punkte > grenzePunkte)
//            {
//                ret = true;
//                break;
//            }
//        }
//    }
//        else
//    {
//        Console.WriteLine("Ünbekannter Filterart angegeben");
//    }
//}
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;

var kunden = new List<Kunde>
{
    new Kunde("Anna", 25, 120),
    new Kunde("Ben", 50, 95),
    new Kunde("Clara", 42, 250),
    new Kunde("David", 38, 180)
};

// TODO: hier gehts los
int aelterAls = 18;
var kundenAelterAlsX = kunden.Any(kunde => kunde.Alter > aelterAls);
kunden.OrderBy(k => k.Alter);

int grenzePunkte = 50;
var kundenMitMehrAlsXPunkten = kunden.Any(kunde => kunde.Punkte > grenzePunkte);

public record Kunde(string Name, int Alter, int Punkte);