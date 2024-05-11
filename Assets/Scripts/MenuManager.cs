using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    public Button BackButton;
    

    public void BackButtonClicked()
    {
        Debug.Log("Button Present");
        SceneManager.LoadScene("Main Menu");
    }

}
