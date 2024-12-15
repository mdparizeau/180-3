using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stick : MonoBehaviour
{
    public Player player;
    private bool ready = false;
    private Collider temp;

    public void Update()
    {
        if (ready)
            temp.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (player.attacked)
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
                temp = other;
                Player.coins += other.gameObject.GetComponent<Crate>().coin_value;
                other.gameObject.SetActive(false);
                ready = false;
                StartCoroutine(RespawnCrate());
            }
            if (other.gameObject.GetComponent<Door>())
            {
                if (Player.coins >= 50 && other.gameObject.GetComponent<Door>().doorName == "Guess")
                {
                    Player.coins -= 50;
                    SceneManager.LoadScene(other.gameObject.GetComponent<Door>().sceneIndex);
                    Cursor.lockState = CursorLockMode.None;
                }
                else print("You broke!!");
            }
        }
    }
    public IEnumerator RespawnCrate()
    {
        yield return new WaitForSeconds(5f);
        ready = true;
    }
}
