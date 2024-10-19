using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Simulator : MonoBehaviour
{
    public GameObject SimulatorScreen; // Fixed naming inconsistency from "SimulationScreen"
    public List<Contestant> contestants; // List of all contestants in the simulation
    public List<Tribe> tribes; // List of all tribes in the simulation
    public GameObject EventPrefab; // Prefab to display individual events
    public GameObject EventScreen;
    //public Button button; // Added the button reference for consistency

    // List of potential positive and negative events
    public string[] posAllies = { "Find Something in Common", "Bond Strongly", "Bond Slightly" };
    public string[] negAllies = { "Have a Minor Disagreement", "Has a Major Meltdown", "Have a Small Fight", "Have a Major Disagreement", "Have a Major Fight" };

    // Start is called before the first frame update
    public void StartSimulation()
    {
        Debug.Log("Simulation Started");

        // Initialize relationships between contestants
        foreach (var contestant in contestants)
        {
            foreach (var contestant2 in contestants)
            {
                if (contestant != contestant2)
                {
                    contestant.AddRelationship(new Relationship(contestant2));
                }
            }
        }
        Simulate();
    }

    // Runs the main Simulation
    public void Simulate()
    {
        // Destroy any existing event screen and hide the start screen
        Destroy(GameObject.Find("Event(Clone)"));
        
        // Show Simulation screen and hide start screen
        //GameObject.Find("StartScreen").SetActive(false);
        SimulatorScreen.SetActive(true);
        
        // Assign contestants to their tribe
        foreach (var tribe in tribes)
        {
            foreach (var contestant in tribe.TribeSelector.GetComponent<TribeSelector>().TribeSlots)
            {
                tribe.tribeMembers.Add(contestants.Find(c => c.name == contestant.name));
            }
        }

        // Pick a random event for two people
        AllyEvent allyEvent = PickEvent(tribes[0].tribeMembers[new System.Random().Next(0, 8)], tribes[0].tribeMembers[new System.Random().Next(0, 8)]);
        Debug.Log("Ally Event: " + allyEvent);
        CreateEventVisual(allyEvent);
    }

    // Picks an ally event between two contestants
    AllyEvent PickEvent(Contestant C1, Contestant C2)
    {
        float mod = UnityEngine.Random.Range(-1.0f, 1.0f);
        string desc;

        if (mod > 0)
        {
            desc = posAllies[new System.Random().Next(0, posAllies.Length)];
        }
        else
        {
            desc = negAllies[new System.Random().Next(0, negAllies.Length)];
        }

        Debug.Log(desc);
        AllyEvent allyEvent = new AllyEvent(mod, desc, C1, C2);
        Debug.Log(C1.name + " and " + C2.name + " " + allyEvent.ToString());
        return allyEvent;
    }

    // Creates a visual representation of the event
    void CreateEventVisual(AllyEvent allyEvent)
    {
        // Instantiate the EventPrefab in the root of the scene or specific screen
        GameObject event1 = Instantiate(EventPrefab, SimulatorScreen.transform);

        // Set the position of the event UI element (adjust as necessary)
        event1.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0); // Centered position

        // Set the scale to keep it properly sized
        event1.transform.localScale = Vector3.one;
        event1.transform.GetChild(0).GetComponent<TMP_Text>().text = allyEvent.contestant1.name + " and " + allyEvent.contestant2.name + " " + allyEvent.ToString();
        event1.transform.GetChild(1).GetComponent<Image>().sprite = allyEvent.contestant1.Image.GetComponent<Image>().sprite;
        event1.transform.GetChild(2).GetComponent<Image>().sprite = allyEvent.contestant2.Image.GetComponent<Image>().sprite;
    }
}
