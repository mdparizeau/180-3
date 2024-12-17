using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/3/24
/// Description: Controls the variables of various doors
/// </summary>
public class Door : MonoBehaviour
{
    // Initializes variables for the door variants to utilize
    public int sceneIndex;
    public string doorName;
    public TMP_Text destination;

    public void Start()
    {
        // Sets the guessing "door" to take the player to the guessing scene
        if (doorName == "Guess")
        {
            sceneIndex = 5;
        }
        // Sets the quit door to take the player to the end screen
        if (doorName == "Quit")
        {
            sceneIndex = 6;
        }
    }
    /// <summary>
    /// Updates the coin door's index, increasing with the player's level
    /// </summary>
    public void Update()
    {
        destination.text = doorName;
        if (doorName == "Coin")
        {
            sceneIndex = Player.level + 2;
        }
    }
}
