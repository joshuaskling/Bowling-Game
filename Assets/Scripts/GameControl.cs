using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public Transform playerBall;
	public Transform initialThrowPosition;
	private bool viewState;


	// Use this for initialization
	void Start () {
		viewState = false;
	}

	//Fire ball
	//void fireBall(){
		//GameObject go = (GameObject) Instantiate (Resources.Load ("PlayerBall"));
		//go.transform.position = new Vector3(0f, 0f, 0f);
		//Transform ball = (Transform) Instantiate(playerBall, transform.position, transform.rotation);

		//reset ball position

	//}

	void resetPositions(){
		playerBall.transform.position = Vector3.Lerp(transform.position, initialThrowPosition.position, .1f);

		BallControl.positionState = true;
	}

	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown ("space")) {
			fireBall ();
		}*/

		if (playerBall.position.z < -8f){
			viewState = true;
		}

		if (viewState == true) {
			//display score

			if (Input.GetMouseButtonDown(0)){
				resetPositions();
			}
		}

		if (Input.GetKey("escape"))
			Application.Quit();
		}
}
