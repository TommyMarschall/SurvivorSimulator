using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class Simulator : MonoBehaviour
{
<<<<<<< Updated upstream
    public GameObject SimulationScreen;
    public List<Contestant> contestants;
    public List<Tribe> tribes;
    public GameObject EventPrefab;
    public GameObject EventScreen;
    // Start is called before the first frame update
    private Button button;
    //Initalizes the simulation by setting up relationships between contestants
    public void StartSimulation(){
=======
    public GameObject SimulatorScreen;
    public List<Contestant> contestants; // List of all contestants in the simulation
    public List<Tribe> tribes; // List of all tribes in the simulation
    public GameObject EventPrefab; // Prefab to display individual events

    public string[] posAllies = { "Find Something in Common", "Bond Strongly", "Bond Slightly" };
    public string[] negAllies = { "Have a Minor Disagreement", "Has a Major Meltdown", "Have a Small Fight", "Have a Major Disagreement", "Have a Major Fight" };

    // Initialize relationships and simulate the events
    public void StartSimulation()
    {
>>>>>>> Stashed changes
        Debug.Log("Simulation Started");

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
    //Runs the main Simulation
    public void Simulate()
    {
        //Destroy any existing screen and hide the start screen
        Destroy(GameObject.Find("Event(Clone)"));
        //Shows Simulation screen and hides start screen
        GameObject.Find("StartScreen").SetActive(false);
        SimulationScreen.SetActive(true);
        //assign contestants to their tribe
        foreach (var Tribe in tribes)
        {
            foreach (var contestant in Tribe.TribeSelector.GetComponent<TribeSelector>().TribeSlots)
            {
                Tribe.tribeMembers.Add(contestants.Find(c => c.name == contestant.name));
            }
        }
        //Pick random event for two people
        AllyEvent AllyEvent = PickEvent(tribes[0].tribeMembers[new System.Random().Next(0,8)], tribes[0].tribeMembers[new System.Random().Next(0,8)]);
        Debug.Log("Ally Event: " + AllyEvent);
        CreateEventVisual(AllyEvent);

        
    }
    //List of potential positive and negative events
    public string[] posAllies = { "Find Something in Common","Bond Strongly","Bond Slightly"};
    public string[] negAllies = { "Have a Minor Disagreement","Has a Major Meltdown","Have a Small Fight","Have a Major Disagreement","Have a Major Fight"};
    AllyEvent PickEvent (Contestant C1 , Contestant C2)
    {
        float mod = UnityEngine.Random.Range (-1.0f, 1.0f);
        string desc;
        if (mod > 0) 
        { 
            desc = posAllies[new System.Random().Next(0, posAllies.Length)];
        } 
        else { desc = negAllies[new System.Random().Next(0, negAllies.Length)]; } 
        Debug.Log(desc);
        AllyEvent AllyEvent = new AllyEvent(mod,desc,C1,C2);
        Debug.Log(C1.name+" and " +C2.name+" "+AllyEvent.ToString());
        return AllyEvent;
    }
    void CreateEventVisual(AllyEvent AllyEvent)
    {
<<<<<<< Updated upstream
        GameObject event1 = Instantiate(EventPrefab);
        event1.transform.SetParent(null);
        event1.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
=======
        GameObject event1 = Instantiate(EventPrefab,SimulatorScreen.transform); // Instantiate the EventPrefab in the root of the scene
        

        // Set the position of the event UI element (adjust as necessary)
        event1.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0); // Centered position

        // Set the scale to keep it properly sized
>>>>>>> Stashed changes
        event1.transform.localScale = Vector3.one;
        event1.transform.GetChild(0).GetComponent<TMP_Text>().text = AllyEvent.contestant1.name + " and " + AllyEvent.contestant2.name + " " + AllyEvent.ToString();
        event1.transform.GetChild(1).GetComponent<Image>().sprite = AllyEvent.contestant1.Image.GetComponent<Image>().sprite;
        event1.transform.GetChild(2).GetComponent<Image>().sprite = AllyEvent.contestant2.Image.GetComponent<Image>().sprite;
    }

}
