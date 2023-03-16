using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    // Update er kallað einu sinni á hverjum ramma
    void Update()
    {
        // Ef staðsetningin í ásinni z er stærri en topBound
        if (transform.position.z > topBound)
        {
            // Eyða hlutnum
            Destroy(gameObject);
        }
        // Annars ef staðsetningin í ásinni z er minni en lowerBound
        else if (transform.position.z < lowerBound)
        {
            // Skrifa "Game Over!" í console-inn
            Debug.Log("Game Over!");
            // Eyða hlutnum
            Destroy(gameObject);
        }
    }

}
