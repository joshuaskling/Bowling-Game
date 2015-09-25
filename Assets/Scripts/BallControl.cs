using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {
	private float leftright;
	private float updown;
	private float offset = .02f;

	public static bool positionState;
	public static bool throwState;
	public static bool viewState;

	private RaycastHit startHit, endHit;
	private float multiplyer = 50;

	protected Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;

		positionState = true;
		throwState = false;
		viewState = false;
	}

	void fireBall(Vector3 newBallVector){
		//Debug.Log ("fireBall");
		rb.AddForce (newBallVector.x, newBallVector.y, newBallVector.z);
	}
	
	// Update is called once per frame
	void Update () {
		//rb.AddForce (new Vector3 (0f, 0f, -100000f).normalized);

		//leftright = Input.GetAxisRaw ("Horizontal");
		//rb.AddForce (new Vector3 (-leftright, 0f, 0f ).normalized*.1f, ForceMode.Impulse);

		//actions for positioning
		if (positionState == true) {
			//left/right arrow key control
			if (Input.GetKey ("left") && (rb.position.x < .5f)) { 
				rb.MovePosition (new Vector3 (rb.position.x + offset, rb.position.y, rb.position.z));
			} else if (Input.GetKey ("right") && (rb.position.x > -.5f)) {
				rb.MovePosition (new Vector3 (rb.position.x - offset, rb.position.y, rb.position.z));
			}

			//left/right arrow key control
			if (Input.GetKey ("up") && (rb.position.y < .6f)) { 
				rb.MovePosition (new Vector3 (rb.position.x, rb.position.y + offset, rb.position.z));
			} else if (Input.GetKey ("down") && (rb.position.y > 0f)) {
				rb.MovePosition (new Vector3 (rb.position.x, rb.position.y - offset, rb.position.z));
			}
		}

		//actions for throwing
		if (Input.GetMouseButtonDown (0)) {
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			//Debug.Log ("mouse down");

			//get start raycast
			if (Physics.Raycast (camRay, out startHit)) {
				Debug.Log (startHit.point.x);
			}

			//go to pure throwing mode
			positionState = false;

		} else if (Input.GetMouseButtonUp (0)) {
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			//initiate gravity
			if (Input.GetMouseButtonUp (0)) {
				rb.useGravity = true;
				positionState = false;
			}

			//get end raycast
			if (Physics.Raycast (camRay, out endHit)){
				Debug.Log (endHit.point.x);
			}

			//add velocity and fire ball
			Vector3 newBallVector = new Vector3((endHit.point.x - startHit.point.x) * multiplyer,
			                                    1f * multiplyer,
			                                    (endHit.point.z - startHit.point.z) * multiplyer);
			//Debug.Log("mouse button up");
			fireBall(newBallVector);

			//var throwNum: GameControl = GetComponent(GameControl.throw);
		}
	}
}





