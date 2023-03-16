// Notað er Unity samskiptakerfið til að stýra leikmanni í leik.
using UnityEngine;

// Notað er Input System pakka sem gefur möguleika á að hafa stjórn yfir inntaki frá mús, lyklaborði og leikjastýringum.
using UnityEngine.InputSystem;
// Notað er TextMeshProUGUI pakka til að birta texta á skjánum.
using TMPro;

// Búa er til klasa sem heitir PlayerController sem er undir stjórn GameObject í Unity.
public class PlayerController : MonoBehaviour {
	
	// Breyturnar speed, countText og winTextObject eru opin fyrir notandann og eru stilltar áður en leikurinn hefst.
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

        // Einkabreyturnar movementX og movementY eru notuð til að stjórna hreyfingu leikmanns.
        private float movementX;
        private float movementY;

    // Einkabreytan rb er notuð til að ná í Rigidbody samsetninguna sem er fest við GameObjectið sem PlayerController er undir stjórn.
	private Rigidbody rb;
	private int count;

	// Einkabreytan count er notuð til að halda utan um fjölda safnaðra hluta.
	void Start ()
	{
		// Í byrjun leiks er rb stillt sem Rigidbody samsetningin á þessari GameObject.
		rb = GetComponent<Rigidbody>();

		// Fjöldi safnaðra hluta er stilltur sem 0.
		count = 0;

        // SetTextCount() fallið er keyrt til að uppfæra textann sem birtist á skjánum.
		SetCountText ();

                // WinTextObject er falið til að byrja með.
                winTextObject.SetActive(false);
	}

    // Í hverri FixedUpdate() hreyfist leikmaðurinn eftir því hvernig notandinn stjórnar hreyfingunni.
	void FixedUpdate ()
	{

		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		// Ef leikmaðurinn snertir hlut sem hefur tagið "PickUp" þá er safnað einum hliðstæðum fjölda og hluturinn hverfur.
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
	}

        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }

        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
        
        //Ef leikmaðurinn safnar 20 hlutum er birtað skilaboð um sigur.
		if (count >= 20) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
	}
}
