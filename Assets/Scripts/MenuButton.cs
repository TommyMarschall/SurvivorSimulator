using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Scenes sceneEnum;

    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(SwitchScene);
        }
        else
        {
            Debug.LogWarning("No Button component found on this GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchScene ()
    {
        SceneManager.LoadScene(sceneEnum.ToString());
    }
    
  
}
public enum Scenes
{
    MainMenu,Borneo,Australia,Africa,Marquesas,Thailand,Amazon,PearlIslands,AllStars,Vanuatu,Palau
}