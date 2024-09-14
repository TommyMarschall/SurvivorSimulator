using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackButton : MonoBehaviour
{
    public GameObject GameScreen;
    public GameObject StartScreen;
    public GameObject MenuButtons;

    public void GoBack()
    {
        MenuButtons.SetActive(true);
        GameScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
}