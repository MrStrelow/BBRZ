using System.Xml.Linq;

namespace Hunde;

public class Mensch
{
    // private Felder
    private string _name;
    private int _alter;
    private double _happiness;
    private string _darstellung = "😐";

    // hat-Beziehungen:
    private Mensch _myLoveInterest;

    // Konstruktor
    public Mensch(string name, double happiness, int alter)
    {
        this._name = name;
        this._happiness = happiness;
        this._alter = alter;
    }

    public Mensch(string name, double happiness, int alter, Mensch loveInterest) : this(name, happiness, alter)
    {
        this._myLoveInterest = loveInterest;
    }

    //Methoden
    public HundeBesitzer WirdEinHundeBesitzer(Hund hund, bool hatHundeFuehrerschein, int capacity)
    {
        HundeBesitzer einGanzNeuerMensch = new HundeBesitzer(this, hatHundeFuehrerschein, capacity);
        einGanzNeuerMensch.Kaufen(hund);
        return einGanzNeuerMensch;
    }

    public HundeBesitzer MehrereHundeKaufen(Hund[] hunde, bool hatHundeFuehrerschein, int capacity)
    {
        HundeBesitzer einGanzNeuerMensch = new HundeBesitzer(this, hatHundeFuehrerschein, capacity);

        // ❌ unerwünschte Zustände
        if (capacity <= hunde.Length)
        {
            Console.WriteLine($"Fehler! Wir haben zu viele -{capacity}- Hunde als wir betreuen können.");
            return null;
        }

        // ✅ gewünschte Zustände
        foreach (Hund hund in hunde)
        {
            einGanzNeuerMensch.Kaufen(hund);
        }

        return einGanzNeuerMensch;
    }

    public bool DetectLoveTriangle()
    {
        // ❌ unerwünschte Zustände
        if(_myLoveInterest == null) 
        {
            Console.WriteLine("_myLoveInterest ist in DetectLoveTriangle null.");
            return false;
        }

        if (_myLoveInterest._myLoveInterest == null)
        {
            Console.WriteLine("_myLoveInterest._myLoveInterest ist in DetectLoveTriangle null.");
            return false;
        }

        if (_myLoveInterest._myLoveInterest._myLoveInterest == null)
        {
            Console.WriteLine("_myLoveInterest._myLoveInterest._myLoveInterest ist in DetectLoveTriangle null.");
            return false;
        }

        // ✅ gewünschte Zustände
        bool triangle = _myLoveInterest._myLoveInterest._myLoveInterest == this;
        bool selfLove = _myLoveInterest == this;

        return triangle && !selfLove;
    }

    private bool DetectLoveTriangleOfSize(int n)
    {
        // ❌ unerwünschte Zustände
        if (_myLoveInterest == null)
            return false;

        if (_myLoveInterest == this) 
            return false;

        // ✅ gewünschte Zustände
        Mensch next = this;
        for (int i = 0; i < n; i++)
        {
            next = next._myLoveInterest;
            
        }

        return next == this;
    }

    public int DetectLoveTriangleUntilSize(int n)
    {
        int foundUntil = -1;
        
        for (int i = 1; i <= n; i++)
        {
            if(DetectLoveTriangleOfSize(i))
            {
                foundUntil = i;
            }
        }

        return foundUntil;
    }

    public bool DetectMutualLove()
    {
        return this == _myLoveInterest._myLoveInterest;
    }

    // überschriebene Methoden
    public override string ToString()
    {
        return $"{_name}:{_alter}:{_darstellung}";
    }

    // Get-und-Set-Methoden
    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        this._name = name;
    }

    public double GetHappiness()
    {
        return _happiness;
    }

    public void SetHappiness(double happiness)
    {
        this._happiness = happiness;
    }

    public int GetAlter()
    {
        return _alter;
    }

    public void SetAlter(int alter)
    {
        this._alter = alter;
    }

    public Mensch GetLoveInterest()
    {
        return _myLoveInterest;
    }

    public void SetLoveInterest(Mensch loveInterest)
    {
        this._myLoveInterest = loveInterest;
    }

    public string GetDarstellung()
    {
        return _darstellung;
    }

    public void SetDarstellung(string darstellung)
    {
        _darstellung = darstellung;
    }
}
