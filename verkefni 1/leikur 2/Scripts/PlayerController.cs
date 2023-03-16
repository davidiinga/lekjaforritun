using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;

    public GameObject projectilePrefab;

    // Update er kallað einu sinni á hverjum ramma
    void Update()
    {
        // Ef staðsetningin er minni en -xRange
        if (transform.position.x < -xRange)
        {
            // Setja staðsetninguna sem (-xRange, transform.position.y, transform.position.z)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // Ef staðsetningin er stærri en xRange
        if (transform.position.x > xRange)
        {
            // Setja staðsetninguna sem (xRange, transform.position.y, transform.position.z)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // Fá input frá notanda um hliðrun (horizontal)
        horizontalInput = Input.GetAxis("Horizontal");
        // Hliðra hlutinum til hægri af horizontalInput * speed * Time.deltaTime
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Ef notandi ýtir á Space hnappinn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Búa til afrit af projectilePrefab og setja það í staðsetningu hlutarins og snúningnum sem hann á
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

}

