﻿using System.Drawing;

namespace LiveCoding;

class Hamster
{
    // Fields
    private (int x, int y) position;
    private string representation;
    private bool isHungry;

    private static string fedRepresentation = "🐹";
    private static string hungryRepresentation = "😡";

    // has-A-Relation
    private Plane plane;
    private List<Seed> mouth = new List<Seed>();

    // Constructor
    public Hamster(Plane plane)
    {
        this.plane = plane;
    }

    // Methods
    public void Move()
    {
        
    }

    public void NutritionBehaviour()
    {

    }
    public void CollectSeed()
    {

    }

    public (int x, int y) GetPosition()
    {
        return position;
    }
}

