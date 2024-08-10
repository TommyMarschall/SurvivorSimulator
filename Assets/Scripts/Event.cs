using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AllyEvent
{
    public float modifier;
    public string discriptor;
    public Contestant contestant1;
    public Contestant contestant2;
    public AllyEvent(float modifier, string discriptor, Contestant contestant1, Contestant contestant2)
    {
        this.modifier = modifier;
        this.discriptor = discriptor;
        this.contestant1 = contestant1;
        this.contestant2 = contestant2;
    }
    public override string ToString()
    {
        return this.discriptor;
    }
}
