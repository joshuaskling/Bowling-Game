using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public Transform playerBall;


	// Use this for initialization
	void Start () {
		
	}

	//Fire ball
	void fireBall(){
		//GameObject go = (GameObject) Instantiate (Resources.Load ("PlayerBall"));
		//go.transform.position = new Vector3(0f, 0f, 0f);
		//Transform ball = (Transform) Instantiate(playerBall, transform.position, transform.rotation);

		//reset ball position

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			fireBall ();
		}

		if (Input.GetKey("escape"))
			Application.Quit();
		}
}
