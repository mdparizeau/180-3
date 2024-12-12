using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Door : MonoBehaviour
{
    public int sceneIndex;
    public string doorName;
    public TMP_Text destination;

    public void Update()
    {
        destination.text = doorName;
    }
}
