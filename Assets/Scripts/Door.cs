using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public int sceneIndex;
    public string doorName;
    public TMP_Text destination;

    public void Start()
    {
        if (doorName == "Guess")
        {
            sceneIndex = 5;
        }
        if (doorName == "Quit")
        {
            sceneIndex = 6;
        }
    }

    public void Update()
    {
        destination.text = doorName;
        if (doorName == "Coin")
        {
            sceneIndex = Player.level + 2;
        }
    }
}
