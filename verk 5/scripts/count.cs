using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class count : MonoBehaviour
{
    // Public static breyta sem heldur utan um einungis eitt tilvik af klasanum
    public static count instance;

    // Public breyta sem geymir viðmótselementið fyrir texta fyrir fjölda peninga
    public TMP_Text coinText;
    // Public breyta sem geymir núverandi fjölda peninga
    public int currentCoins = 0;

    // Start er kallað þegar hluturinn er búinn til
    void Awake()
    {
        // Tildelum instance breytunni þessum klasa
        instance = this;
    }

    // Start er kallað þegar leikurinn byrjar
    void Start()
    {
        // Breytum textanum á viðmótselementinu til að sýna núverandi fjölda peninga sem "GEMS: currentCoins"
        coinText.text = "GEMS: " + currentCoins.ToString();
    }

    // IncreaseCoins aðferðin eykur fjölda peninga um "v"
    public void IncreaseCoins(int v)
    {
        // Bætum "v" við núverandi fjölda peninga
        currentCoins += v;
        // Breytum textanum á viðmótselementinu til að sýna uppfærðan fjölda peninga sem "GEMS: currentCoins"
        coinText.text = "GEMS: " + currentCoins.ToString();
    }

    // DecreaseCoins aðferðin minnkar fjölda peninga um "v"
    public void DecreaseCoins(int v)
    {
        // Dragum "v" frá núverandi fjölda peninga
        currentCoins -= v;
        // Breytum textanum á viðmótselementinu til að sýna uppfærðan fjölda peninga sem "GEMS: currentCoins"
        coinText.text = "GEMS: " + currentCoins.ToString();
    }
}
