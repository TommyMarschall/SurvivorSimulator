using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class Simulator : MonoBehaviour
{
    public GameObject SimulationScreen;
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
        GameObject.Find("StartScreen").SetActive(false);
        SimulationScreen.SetActive(true);
        foreach (var Tribe in tribes)
        {
            foreach (var contestant in Tribe.TribeSelector.GetComponent<TribeSelector>().TribeSlots)
            {
                Tribe.tribeMembers.Add(contestants.Find(c => c.name == contestant.name));
            }
        }
    }
    public string[] posAllies = { "Find Something in Common","Bond Strongly","Bond Slightly",""};
    public string[] negAllies = { "Have a Minor Disagreement","Has a Major Meltdown","Have a Small Fight","Have a Major Disagreement","Have a Major Fight"};
    void PickEvent (Contestant C1 , Contestant C2)
    {
        float mod = Random.Range (-1.0f, 1.0f);
        string desc;
        if (mod > 0) 
        { 
            desc = posAllies[Random.next(0, posAllies.Length)];
        }
        AllyEvent AllyEvent = new AllyEvent (mod,)
    }
}
