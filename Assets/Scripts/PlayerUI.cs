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
    public TMP_Text controls;
    public TMP_Text continue_dialogue;
    public TMP_Text coins;
    public Player player;

    private void Start()
    {
        // allows player to continue dialogue
        continue_dialogue.text = "";
        // shows player how to move, interact, and attack
        controls.text = "Move: WASD\nAttack: 'Shift'\nInteract: Attack";
    }

    // Update is called once per frame
    void Update()
    {
        // shows how many coins the player has
        coins.text = "Coins: " + player.coins;
    }
}
