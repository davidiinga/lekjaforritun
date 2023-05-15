
// Notkun á þessum pakka og hlutum
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasinn sem stjórnar hreyfingu leikmannsins
public class PlayerMovement : MonoBehaviour
{
  // Public breyta sem heldur utan um CharacterController2D hlutinn
  public CharacterController2D controller;

  // Public breyta sem stjórnar hraða leikmannsins
  public float runSpeed = 40f;

  // Private breytur sem halda utan um hliðrunarhreyfingu og hvort að leikmaðurinn sé að hoppa
  float horizontalMove = 0f;
  bool jump = false;

  // Fall sem keyrir í hverju frame
  void Update()
  {
      // Sækja hliðrunarhreyfingu frá notandanum
      horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

      // Athuga hvort notandinn ýtti á hnappinn "Jump"
      if (Input.GetButtonDown("Jump"))
      {
          jump = true;
      }
  }

  // Fall sem keyrir í fastan tíma
  void FixedUpdate()
  {
    // Flytja leikmanninn með CharacterController2D hlutnum, meðhöndlum hvort hann sé að hoppa eða ekki
    controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

    // Endurstilla hopp breytuna
    jump = false;
  }
}