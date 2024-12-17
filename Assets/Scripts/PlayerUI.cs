using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/10/24
/// Description: Displays text for player
/// </summary>
public class PlayerUI : MonoBehaviour
{
    // Text variables for reference
    public TMP_Text controls;
    public TMP_Text continue_dialogue;
    public TMP_Text coins;

    private void Start()
    {
        // Displays the controls for the player to continue dialogue
        continue_dialogue.text = "";
        // Shows player how to move, interact, and attack
        controls.text = "Move: WASD\nAttack: 'Shift'\nInteract: Attack";
    }

    void Update()
    {
        // Shows how many coins the player has
        coins.text = "Coins: " + Player.coins + "\nLevel: " + Player.level;
    }
}
