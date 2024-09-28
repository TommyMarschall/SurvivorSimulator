using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public string player1; // Name of player 1
    public string player2; // Name of player 2
    public TextMeshProUGUI textbox1; // Reference to the TextMeshProUGUI component
    public List<string> players; // List of player names
    public List<Image> playerProfiles; // List of player profile images
    public List<string> Pagong; // List of players in Tribe Pagong
    public List<string> Tagi; // List of players in Tribe Tagi
    public GameObject eventPrefab; // Prefab for creating UI events

    // Start is called before the first frame update
    void Start()
    {
        player1 = "B.B";  // Initial player 1 name
        player2 = "Colleen";  // Initial player 2 name

        // Create a random alliance text using random players from the players list
        string alliance = players[Random.Range(0, players.Count)] + " and " + players[Random.Range(0, players.Count)] + " formed an alliance";

        // Set the alliance text in the textbox
        textbox1.text = alliance;
    }

    // Update is called once per frame
    void Update()
    {
        // Not used right now, but can be used for updates
    }
}
