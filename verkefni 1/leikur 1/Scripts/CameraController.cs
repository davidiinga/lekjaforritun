// Notað er System.Collections og System.Collections.Generic pakkarnir.
using System.Collections;
using System.Collections.Generic;

// Notað er Unity samskiptakerfið til að stýra myndavélinni í leik.
using UnityEngine;

// Búa er til klasa sem heitir CameraController sem er undir stjórn GameObject í Unity.
public class CameraController : MonoBehaviour
{

    // Public breytan player er til að láta notandann velja hlut sem myndavélin á að fylgja með.
    public GameObject player;
    // Private breytan offset er notuð til að halda utan um fjarlægð milli myndavélar og leikmanns.
    private Vector3 offset;

    // Í Start() fallinu er offset stillt sem fjarlægðin milli myndavélar og leikmanns.
    void Start()
    {
        offset = transform.position - player. transform.position;
    }

    // LateUpdate() er fall sem er keyrt einu sinni á hverjum frame. Myndavélin er stillt svo að hún fylgir leikmanninum með offset-i.
    void LateUpdate()
    {
        transform.position = player. transform.position + offset;
    }
}
