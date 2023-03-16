// Notað er UnityEngine og System.Collections pakka í C# kóðanum.
using UnityEngine;
using System.Collections;

// Búa er til klasa sem heitir Rotator sem er undir stjórn GameObject í Unity.
public class Rotator : MonoBehaviour {

	// Update() er fall sem er keyrt einu sinni á hverjum frame.
	void Update () 
	{
        // transform.Rotate() snýr GameObject-inu sem þetta script er tengt við um 15 í X ás, 30 í Y 
        // ás og 45 í Z ás. Tími er margfaldað með deltaTime til að snúningurinn sé per sekúndu fremur en per frame.
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}