using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    // tékka eftir árekstri
    void OnCollisionEnter(Collision collision)
    {
        // ef að áreksturinn er með tag "meety" 
        //þá eðilegst hann
        if (collision.gameObject.tag == "meety")
        {
            Destroy (gameObject);
        }

    }
}
