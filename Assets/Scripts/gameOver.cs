using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public Animator animator;
    public TMP_Text outcome;
    //public Player player;

    private void Start()
    {
        //player = gameObject
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!GetComponent<Player>().is_quitter)
            outcome.text = "Quitter!!";
        else if (GetComponent<Player>().is_quitter)
            outcome.text = "Winner!!";
        */
    }

    
}
