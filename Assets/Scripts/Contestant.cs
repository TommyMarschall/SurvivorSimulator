using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Contestant 
{
    public string name;
    public string tribe;
    public GameObject Image;
    public List<Relationship>  relationships;
    public Contestant(string name, string tribe)
    {
        this.name = name;
        this.tribe = tribe;
    }
    public void AddRelationship(Relationship r)
    {
        if (relationships == null)
        {
            relationships=new List<Relationship> ();
        }
          relationships.Add(r);
    }
}
