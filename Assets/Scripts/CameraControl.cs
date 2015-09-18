using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	Vector3 offset = new Vector3(0f,0f,0f);
	GameObject ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("PlayerBall");
		offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ball.transform.position + offset;
	}
}
