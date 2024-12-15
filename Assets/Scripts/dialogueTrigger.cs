using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dialogueTrigger : MonoBehaviour
{
    public dialogue Dialogue;
    public TMP_Text name;
    public bool doer;
    public Text myText;

    public void Start()
    {
        myText = GetComponent<Text>();
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(Dialogue);
    }
    public void Update()
    {
        name.text = Dialogue.name;
        myText.color = Color.green;
    }
    public void checkDoer()
    {
        if (doer)
            SceneManager.LoadScene(6);
        else
        {
            SceneManager.LoadScene(1);
            print("You were indeed, incorrect.");
        }
    }
}
