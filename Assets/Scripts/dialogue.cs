using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/16/24
/// Description: Space to store the name and lines for each NPC
/// </summary>
[System.Serializable]
public class dialogue
{
    // Name attached to the NPC
    public string name;
    // How big the textbox area is in the Inspector
    [TextArea(3, 10)]
    // Open-ended array for sentences
    public string[] sentences;
}
