using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    string player1;
    string player2;
    public TextMeshProUGUI textbox1;
    public List<string> players;
    public List<Image> playerProfiles;
    public List<string> Pagong;
    public List<string> Tagi;
    public GameObject gameObject;

    
    // Start is called before the first frame update
    void Start()
    {
       /* for (int i = 0; i < 8; i++) {
            Pagong.Add(players[i]);
        }
      
        for (int i = 0; i < 8; i++)
        {
            Tagi.Add(players[i]);
        }*/
        player1 = "B.B";
        player2 = "Colleen";
        string alliance = players[Random.Range(0,15)] + " and " +  players[Random.Range(0,15)] + " formed an alliance";

        textbox1.text = alliance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
