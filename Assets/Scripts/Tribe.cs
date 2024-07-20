using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Tribe 
{
    public List<Contestant> tribeMembers;
    public string name;
    public GameObject TribeSelector;
    public Tribe (string name)
    {
        this.name = name;
        this.tribeMembers = new List<Contestant>();
    }
}
