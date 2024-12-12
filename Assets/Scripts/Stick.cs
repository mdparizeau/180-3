using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public Player player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<dialogueTrigger>())
        {
            // start the dialogue
            other.gameObject.GetComponent<dialogueTrigger>().TriggerDialogue();
            // disable Player's keyboard and mouse movement
            player.moveSpeed = 0f;
            FindObjectOfType<MouseLook>().sensitivity = 0f;
            FindObjectOfType<PlayerUI>().continue_dialogue.text = "Press 'Q' to continue NPC dialogue";
        }
        if (other.gameObject.GetComponent<Crate>())
        {
            player.coins += other.gameObject.GetComponent<Crate>().coin_value;
            other.gameObject.SetActive(false);
        }
    }
}
