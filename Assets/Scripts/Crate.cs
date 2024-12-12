using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crate : MonoBehaviour
{
    public int coin_value = 1; // how many coins are in the crate
    private float min = 1;
    private float max = 5;
    public int multiplier = 1;

    public TMP_Text coinText;

    public void Start()
    {
        InvokeRepeating("randomizeCoinValue", 0, 0.5f);
        max *= multiplier;
        min *= multiplier;
    }

    public void Update()
    {
        coinText.text = "Coins: " + coin_value.ToString();
    }
    void randomizeCoinValue()
    {
        coin_value = (int)Random.Range(min, max);
    }
}
