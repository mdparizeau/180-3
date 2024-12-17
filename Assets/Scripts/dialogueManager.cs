using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/16/24
/// Description: Controls the player-NPC dialogue, managing when to go to the next line, and when to end the dialogue.
/// </summary>
public class dialogueManager : MonoBehaviour
{
    // Text to be used in the text box
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    // Animator to allow movement of the dialogue UI components
    public Animator animator;
    // Queue for NPC dialogue
    private Queue<string> sentences;
    // Variables for keeping track of which lines of dialogue to feature
    private int counter = 0;
    private string discard;
    public bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    // Allows the player control of when moving to the next line
    void Update()
    {
        if (counter > 0 && Input.GetKeyDown("q"))
        {
            DisplayNextSentence();
        }
    }
    /// <summary>
    /// Starts the dialogue by displaying the UI components, loading up the sentences, and starting the first sentence.
    /// </summary>
    /// <param name="Dialogue"></param>
    public void StartDialogue (dialogue Dialogue)
    {
        finished = false;

        animator.SetBool("isOpen", true);

        nameText.text = Dialogue.name;

        sentences.Clear();

        foreach (string sentence in Dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        // ensures the NPCs display the correct lines crresponding with the Player's level
        for (int i = 0; i < Player.level * 3; i++)
            discard = sentences.Dequeue();

        counter = 0;

        DisplayNextSentence();
    }
    /// <summary>
    /// Function to be activated by the Player pressing the 'q' key
    /// Displays the next sequential line attachted to the NPC
    /// </summary>
    public void DisplayNextSentence()
    {
        if (counter == 3 || sentences.Count == 0)
        {
            EndDialogue();
            //figure out how to get the actual text
            //dT.name.color = new Color(1f, 1f, 1f, 0.8f);
            //dialogue.GetComponent<dialogueTrigger>().name.color = new Color(1f, 1f, 1f, 1.0f);
            return;
        }


        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        counter++;
    }
    /// <summary>
    /// Coroutine to have each letter be displayed individually
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    /// <summary>
    /// When the dialogue is over, removes the UI display, and re-allows the player to move
    /// </summary>
    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation.");
        FindObjectOfType<Player>().moveSpeed = 5f;
        FindObjectOfType<MouseLook>().sensitivity = 20f;
        FindObjectOfType<PlayerUI>().continue_dialogue.text = "";
        finished = true;
    }

}
