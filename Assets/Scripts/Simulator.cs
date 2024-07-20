using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Simulator : MonoBehaviour
{
    public List<Contestant> contestants;
    public List<Tribe> tribes;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var contestant in contestants)
        {
            foreach(var contestant2 in contestants)
            {
                if (contestant != contestant2)
                {
                    contestant.AddRelationship(new Relationship(contestant2));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Simulate()
    {
        foreach (var Tribe in tribes)
        {
            foreach (var contestant in Tribe.TribeSelector.GetComponent<TribeSelector>().TribeSlots)
            {
                Tribe.tribeMembers.Add(contestants.Find(c => c.name == contestant.name));
            }
        }
    }
}
