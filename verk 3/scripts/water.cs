using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class water : MonoBehaviour
{

    // OnTriggerEnter keyrir þegar hluturinn er snertur af öðrum hlut með Collider á honum
    public void OnTriggerEnter(Collider Col)
    {
        // Athugum hvort hluturinn sem snertist hefur merkið "water"
        if(Col.gameObject.tag == "water")
        {
            // Ef hluturinn sem snertist er "water" þá hlaðum við inn "GameOver" borðinu
            SceneManager.LoadScene("GameOver");
        }
    }


}
