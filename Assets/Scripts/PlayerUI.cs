using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/10/24
/// Description: Displays text for player
/// </summary>
public class PlayerUI : MonoBehaviour
{
    public TMP_Text controls;
    public TMP_Text continue_dialogue;

    private void Start()
    {
        // allows player to continue dialogue
        continue_dialogue.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // shows player how to move and interact
        controls.text = "Move: WASD\nInteract: Run into things";
    }
}
