using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Simulator : MonoBehaviour
{
    public List<Contestant> contestants; // List of all contestants in the simulation
    public List<Tribe> tribes; // List of all tribes in the simulation
    public GameObject EventPrefab; // Prefab to display individual events

    public string[] posAllies = { "Find Something in Common", "Bond Strongly", "Bond Slightly" };
    public string[] negAllies = { "Have a Minor Disagreement", "Has a Major Meltdown", "Have a Small Fight", "Have a Major Disagreement", "Have a Major Fight" };

    // Initialize relationships and simulate the events
    public void StartSimulation()
    {
        Debug.Log("Simulation Started");

        // Create relationships between contestants
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

    // Runs the main simulation logic
    public void Simulate()
    {
        // Pick a random AllyEvent between two contestants in the first tribe
        AllyEvent allyEvent = PickEvent(contestants[Random.Range(0, contestants.Count)], contestants[Random.Range(0, contestants.Count)]);
        Debug.Log("Ally Event: " + allyEvent);

        // Create a visual representation of the event
        CreateEventVisual(allyEvent);
    }

    // Picks a random event based on a relationship modifier
    AllyEvent PickEvent(Contestant C1, Contestant C2)
    {
        float mod = UnityEngine.Random.Range(-1.0f, 1.0f); // Random relationship modifier
        string desc;

        if (mod > 0)
        {
            desc = posAllies[Random.Range(0, posAllies.Length)];
        }
        else
        {
            desc = negAllies[Random.Range(0, negAllies.Length)];
        }

        Debug.Log(desc);

        AllyEvent allyEvent = new AllyEvent(mod, desc, C1, C2);
        Debug.Log(C1.name + " and " + C2.name + " " + allyEvent.ToString());

        return allyEvent;
    }

    // Creates a visual representation of the event in the root of the scene
    void CreateEventVisual(AllyEvent allyEvent)
    {
        GameObject event1 = Instantiate(EventPrefab); // Instantiate the EventPrefab in the root of the scene
        event1.transform.SetParent(null); // This ensures it is not a child of any UI element

        // Set the position of the event UI element (adjust as necessary)
        event1.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0); // Centered position

        // Set the scale to keep it properly sized
        event1.transform.localScale = Vector3.one;

        // Display event details on the UI
        event1.transform.GetChild(0).GetComponent<TMP_Text>().text = allyEvent.contestant1.name + " and " + allyEvent.contestant2.name + " " + allyEvent.ToString();

        // Access the Image component and set the sprite
        event1.transform.GetChild(1).GetComponent<Image>().sprite = allyEvent.contestant1.Image.GetComponent<Image>().sprite;
        event1.transform.GetChild(2).GetComponent<Image>().sprite = allyEvent.contestant2.Image.GetComponent<Image>().sprite;
    }

}
