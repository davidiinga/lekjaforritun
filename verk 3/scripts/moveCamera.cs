using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

// Færslupunkturinn fyrir myndavélina er skilgreindur sem Transform
public Transform cameraPosition;

// Update fallið er kallað í hverja ramma í leiknum
private void Update()
{
    // Staðsetning kvarðans er sett sem staðsetning færslupunktsins fyrir myndavélina
    transform.position = cameraPosition.position;
}

}
