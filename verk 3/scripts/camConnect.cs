using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camConnect : MonoBehaviour
{

    public Transform orientation;  // Stjórnarhorn hreyfingarhorfs

    float xRotation;  // Breyta fyrir X-ás hreyfingu
    float yRotation;  // Breyta fyrir Y-ás hreyfingu

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Læsir músarbendli á myndavélina
        Cursor.visible = false;  // Felur músarbendilinn á skjánum
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;  // Færsla músarbendils á X-ás
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;  // Færsla músarbendils á Y-ás

        yRotation += mouseX;  // Færsla músarbendils á X-ás bætt við yRotation

        xRotation -= mouseY;  // Færsla músarbendils á Y-ás dregin frá xRotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Breytur xRotation takmörkuð á milli -90 og 90 gráður

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);  // Setur hornið á myndavélina
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);  // Setur hornið á stjórnarhornið
    } 


}
