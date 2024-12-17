using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/11/24
/// Description: Controls the variables of the crate object
/// </summary>
public class Crate : MonoBehaviour
{   // How many coins are in the crate
    public int coin_value = 1;
    // Min and max base value of each crate
    private float min = 1;
    private float max = 5;
    // Public variable to change multiplier of crate variants
    public int multiplier = 1;
    // Text to display the value of the crates
    public TMP_Text coinText;

    public void Start()
    {
        // Start the constant modifier of the crate's value
        InvokeRepeating("randomizeCoinValue", 0, 0.5f);
        // Compensate for the crate variants
        max *= multiplier;
        min *= multiplier;
    }
    
    public void Update()
    {
        // Update the text in real time to what it's worth
        coinText.text = "Coins: " + coin_value.ToString();
    }
    /// <summary>
    /// Gets a random number within the range to apply to the value of the crate
    /// </summary>
    void randomizeCoinValue()
    {
        coin_value = (int)Random.Range(min, max);
    }
}
