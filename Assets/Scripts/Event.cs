using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AllyEvent
{
    public float modifier;
    public string discriptor;
    public AllyEvent(float modifier, string discriptor)
    {
        this.modifier = modifier;
        this.discriptor = discriptor;
    }
    public override string ToString()
    {
        return this.discriptor;
    }
}
