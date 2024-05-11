using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextPage : MonoBehaviour
{
    public string sceneName;


    public void NextButtonClicked()
    {
        Debug.Log("Button Present");
        SceneManager.LoadScene(sceneName);
    }

}
