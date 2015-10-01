using UnityEngine;
using System.Collections;

public class PinBehavior : MonoBehaviour {

	protected Rigidbody pin;
	public bool knocked;
	//public Transform startPos;
	public Vector3 startPos;

	//check if pin knocked over
	void knockCheck(){
		if (knocked == false && pin.transform.up.y < .5f) {
			GameControl.increaseScore(1);
			knocked = true;
		}

		//Debug.Log (pin.gameObject.name + ": " + pin.transform.up.y + " knocked=" + knocked);
	}

	//set pin aside
	/*public static void safePin(){
		pin.transform.position = new Vector3 (0f, 0f, 0f);
	}*/

	// Use this for initialization
	void Start () {
		pin = GetComponent<Rigidbody> ();
		knocked = false;
		/*startPos.transform.position = new Vector3 (pin.transform.localPosition.x,
		                                           pin.transform.localPosition.y,
		                                           pin.transform.localPosition.z);*/
		startPos = new Vector3 (pin.gameObject.transform.position.x,
		                        pin.gameObject.transform.position.y,
		                        pin.gameObject.transform.position.z);

		//Debug.Log (startPos.transform.position.x);
	}

	//reset pin
	void reset(){
		Debug.Log ("reset");

		if (knocked == true) {
			pin.transform.up = new Vector3(0f,0f,0f);
			pin.transform.position = new Vector3 (0f,pin.transform.position.y - 10f,0f);
			pin.constraints = RigidbodyConstraints.FreezeAll;
		}
	}

	//final reset
	void resetAll(){
		Debug.Log ("final reset");

		pin.transform.up = new Vector3(0f,0f,0f);

		pin.transform.position = new Vector3( startPos.x,
			                                 startPos.y,
			                                 startPos.z);
		pin.constraints = RigidbodyConstraints.None;

		knocked = false;
	}
	
	// Update is called once per frame
	void Update () {
		knockCheck ();


	}
}
