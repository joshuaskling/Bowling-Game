using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	Vector3 offset = new Vector3(0f,0f,0f);
	GameObject ball;
	public Transform pinView;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("PlayerBall");
		offset = transform.position - ball.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("ball pos: " + ball.transform.position.z);

		if (ball.transform.position.z > -7f) {
			transform.position = ball.transform.position + offset;
			//if (Time.timeScale != 1.0f) {
				//Time.timeScale = 1.0f;
			//}

		} else if(ball.transform.position.z > -8f){
			//Time.timeScale = .8f;
			transform.position = Vector3.Lerp(transform.position, pinView.position, .1f);
		} else {
			//if (Time.timeScale == 1.0f){
				//Time.timeScale = 1.0f;
			//}
			//transform.position = new Vector3(0f,transform.position.y,transform.position.z);
		}
	}
}
