 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Texti sem birtir núverandi tíma á skjánum.
    public TextMeshProUGUI timer;

    // Fall sem keyrir þegar hlutur er búinn til.
    void Start()
    {
        // Núverandi tími verður byrjunartími.
        currentTime = startingTime;
    }

    // Fall sem keyrir á hverri myndrænni uppfærslu.
    void Update()
    {
        // Drögum frá tímann hverja myndræna uppfærslu.
        currentTime -= 1 * Time.deltaTime;

        // Uppfærum textann sem birtir núverandi tíma.
        timer.text = currentTime.ToString("0");

        // Ef tíminn er minni en eða jafnt og núll, hlaðum við game over stikunni.
        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

}

