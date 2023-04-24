using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class collect : MonoBehaviour

{
    public TextMeshProUGUI score;
    public int coins;
    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Coin")
        {
            coins += 1;
            score.text = coins.ToString("0");
            Col.gameObject.SetActive(false);
            if(coins == 22){
                SceneManager.LoadScene("Win");
            }
        }
    }


}
