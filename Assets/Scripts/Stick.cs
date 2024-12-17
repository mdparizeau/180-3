using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/10/24
/// Description: Script to manage the interactions initiated by attacking (with the stick)
/// </summary>
public class Stick : MonoBehaviour
{
    // Allows reference to the player
    public Player player;
    // Variable to tell the computer when to respawn the crate
    private bool ready = false;
    // Variable to tell the computer which crate to respawn
    private Collider temp = null;

    // Checks, and if applicable, respawns the crate
    public void Update()
    {
        if (temp != null)
        {
            if (temp.gameObject.GetComponent<Crate>() && ready)
                temp.gameObject.SetActive(true);
            else if (temp.gameObject.GetComponent<dialogueTrigger>() && FindObjectOfType<dialogueManager>().finished)
                temp.gameObject.GetComponent<dialogueTrigger>().name.color = new Color(1f, 1f, 1f, 0.8f);
        }
    }
    /// <summary>
    /// Function to allow the player to interact with different in-game objects by attacking
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // Check if the player swung the stick
        if (player.attacked)
        {
            // Check if the attacked object is an NPC
            if (other.gameObject.GetComponent<dialogueTrigger>())
            {
                temp = other;
                // start the dialogue
                other.gameObject.GetComponent<dialogueTrigger>().TriggerDialogue();
                // disable Player's keyboard and mouse movement
                player.moveSpeed = 0f;
                FindObjectOfType<MouseLook>().sensitivity = 0f;
                FindObjectOfType<PlayerUI>().continue_dialogue.text = "Press 'Q' to continue NPC dialogue";
            }
            // Check if the attacked object is a crate
            if (other.gameObject.GetComponent<Crate>())
            {
                // Assign the object to a temp variable
                temp = other;
                // Add coins to the player
                Player.coins += other.gameObject.GetComponent<Crate>().coin_value;
                // Disable the crate
                other.gameObject.SetActive(false);
                ready = false;
                // Allow the respawn of the inactive crate
                StartCoroutine(RespawnCrate());
            }
            // Check if the attacked object is a door
            if (other.gameObject.GetComponent<Door>())
            {
                // Check if the "door" is the guesser cube and if the player has enough money to access it
                if (Player.coins >= 50 && other.gameObject.GetComponent<Door>().doorName == "Guess")
                {
                    // Subtract the cost to guess
                    Player.coins -= 50;
                    // Load the scene, allowing the player to guess which NPC "did the thing"
                    SceneManager.LoadScene(other.gameObject.GetComponent<Door>().sceneIndex);
                    Cursor.lockState = CursorLockMode.None;
                }
                else print("You broke!!");
            }
        }
    }
    /// <summary>
    /// Coroutine to allow the crates to respawn
    /// </summary>
    /// <returns></returns>
    public IEnumerator RespawnCrate()
    {
        yield return new WaitForSeconds(5f);
        ready = true;
    }
}
