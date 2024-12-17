using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/16/24
/// Description: Allows the start of dialogue, called in the Player script
/// </summary>
public class dialogueTrigger : MonoBehaviour
{
    // Initializing variables for reference and modulation
    public dialogue Dialogue;
    public TMP_Text name;
    public bool doer;

    // Start the script changing it's name and color
    public void Start()
    {
        name.text = Dialogue.name;
        // 1st=red, 2nd=green, 3rd=blue, 4th=alpha
        name.color = new Color(0f, 1f, 0f, 1.0f);
    }
    // Reroute opporations to the dialogueManager script
    public void TriggerDialogue()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(Dialogue);
    }
    // Checks if the NPC is the one that did the thing
    public void checkDoer()
    {
        if (doer)
        {
            Player.is_quitter = false;
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(1);
            print("You were indeed, incorrect.");
        }
    }
}
