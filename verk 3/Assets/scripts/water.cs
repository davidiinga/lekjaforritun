using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class water : MonoBehaviour
{

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "water")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
