using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatorStartScreenEpicHandler : MonoBehaviour
{
    public GameObject ButtonsUI;
    public GameObject StartScreenUI;
    public GameObject SimulatorScreenUI;

    public Simulator simulator;
    public void printName(string str)
    {
        Debug.Log($"{str}:was pressed");
    }
    public void StartSimulation()
    {
        Debug.Log("Starting Simulation");

           ButtonsUI.SetActive(false);
           SimulatorScreenUI.SetActive(true);
           StartScreenUI.SetActive(false);
           simulator.StartSimulation();


    }
 
}
