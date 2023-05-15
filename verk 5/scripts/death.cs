
// Nota System.Collections þjónustu til að nota sérstök safn
// Nota System.Collections.Generic þjónustu til að nota safn með tilgreindum tegundum
// Nota UnityEngine þjónustu til að fá aðgang að Unity leikjakerfinu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Búa til klasa sem heitir death og er af Unity MonoBehaviour gerðinni
public class death : MonoBehaviour
{
    // Skilgreina OnTriggerEntger2D fallið sem tekur inn Collider2D hlut sem viðfang
    void OnTriggerEnter2D(Collider2D other)
    {
        // Athuga hvort annar hluturinn sem rekst á þennan hlut hafi merkið "Player"
        if(other.gameObject.CompareTag("Player"))
        {
            // Kalla á DecreaseCoins() aðferðina í count.instance hlutinum og minnka myntina um 1
            count.instance.DecreaseCoins(1);
        }
    }
}