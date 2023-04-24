using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class collect : MonoBehaviour

{

    // OnTriggerEnter kallar þegar hluturinn snertir öðrum Collider.
    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Coin") // Ef tag-ið á hlutnum er "Coin".
        {
            coins += 1; // Bætir við einni mynt á coins.
            score.text = coins.ToString("0"); // Uppfærir score strenginn í skjánum.
            Col.gameObject.SetActive(false); // Setur hlutinn sem snertið var á óvirkan.
            if(coins == 22){ // Ef allar 22 myntirnir eru sóttar.
                SceneManager.LoadScene("Win"); // Hlaða inn "Win" scene.
            }
        }
    }

}
