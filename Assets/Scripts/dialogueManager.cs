using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    private int counter = 0;

    private string discard;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (counter > 0 && Input.GetKeyDown("q"))
            DisplayNextSentence();
    }

    public void StartDialogue (dialogue Dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = Dialogue.name;

        sentences.Clear();

        foreach (string sentence in Dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        for (int i = 0; i < Player.level * 3; i++)
            discard = sentences.Dequeue();

        counter = 0;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (counter == 3 || sentences.Count == 0)
        {
            EndDialogue();
            return;
        }


        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        counter++;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation.");
        FindObjectOfType<Player>().moveSpeed = 5f;
        FindObjectOfType<MouseLook>().sensitivity = 20f;
        FindObjectOfType<PlayerUI>().continue_dialogue.text = "";
    }

}
