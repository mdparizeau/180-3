using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/3/24
/// Description: Displays the ending status of the player
/// </summary>
public class gameOver : MonoBehaviour
{
    public Animator animator;
    public TMP_Text outcome;

    /// <summary>
    /// Changes ending text based off of in the player quit or won the game
    /// </summary>
    void Update()
    {
        if (Player.is_quitter)
        {
            outcome.text = "Quitter!!";
            outcome.color = new Color(1f, 0.2f, 0f, 1.0f);
        }
        else if (!Player.is_quitter)
        {
            outcome.text = "Winner!!";
            outcome.color = new Color(0f, 1f, 0.2f, 1.0f);
        }
    }
}
