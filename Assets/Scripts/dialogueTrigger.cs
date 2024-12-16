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

    public void Start()
    {
        name.text = Dialogue.name;
        // 1st=red, 2nd=green, 3rd=blue, 4th=alpha
        name.color = new Color(0f, 1f, 0f, 1.0f);
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(Dialogue);
    }
    public void Update()
    {
        
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
