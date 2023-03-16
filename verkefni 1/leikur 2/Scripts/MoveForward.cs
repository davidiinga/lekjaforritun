using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    // Update er kallað einu sinni á hverjum ramma
    void Update()
    {
        // Færa hlutinn ífram áfram um tíma(Time.deltaTime) sinnum hraðan(speed) með Translate fallinu í Unity
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

}
