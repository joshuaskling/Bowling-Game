using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public Rigidbody ball;
	public Transform playerBall;
	public Transform initialThrowObject;
	public GameObject pin1;
	public GameObject pin2;
	public GameObject pin3;
	public GameObject pin4;
	public GameObject pin5;
	public GameObject pin6;
	public GameObject pin7;
	public GameObject pin8;
	public GameObject pin9;
	public GameObject pin10;

	public static int throwNum;
	public static int totalThrowNum;
	public static int score;
	public static int finalScore;
	public static int round;

	// Use this for initialization
	void Start () {
		score = 0;
		finalScore = 0;
		throwNum = 0;
		round = 0;
	}

	//increase score
	public static void increaseScore(int amount){
		score += amount;
	}

	public static void controlThrowNum(){
		Debug.Log (throwNum);
		if (throwNum == 0) {
			throwNum++;
			round++;
			finalScore += score;
			score = 0;
		} else {
			throwNum = 0;
		}
	}

	void resetPositions(){
		ball.transform.position = new Vector3 (initialThrowObject.transform.position.x, 
		                                       initialThrowObject.transform.position.y, 
		                                       initialThrowObject.transform.position.z);

		BallControl.positionState = true;
		ball.constraints = RigidbodyConstraints.FreezeAll;

		if (throwNum == 1) {
			//reset pins
			pin1.BroadcastMessage ("reset");
			pin2.BroadcastMessage ("reset");
			pin3.BroadcastMessage ("reset");
			pin4.BroadcastMessage ("reset");
			pin5.BroadcastMessage ("reset");
			pin6.BroadcastMessage ("reset");
			pin7.BroadcastMessage ("reset");
			pin8.BroadcastMessage ("reset");
			pin9.BroadcastMessage ("reset");
			pin10.BroadcastMessage ("reset");
		} else if (throwNum==0){
			pin1.BroadcastMessage ("resetAll");
			pin2.BroadcastMessage ("resetAll");
			pin3.BroadcastMessage ("resetAll");
			pin4.BroadcastMessage ("resetAll");
			pin5.BroadcastMessage ("resetAll");
			pin6.BroadcastMessage ("resetAll");
			pin7.BroadcastMessage ("resetAll");
			pin8.BroadcastMessage ("resetAll");
			pin9.BroadcastMessage ("resetAll");
			pin10.BroadcastMessage ("resetAll");
		}
	}

	// Update is called once per frame
	void Update () {

		//Debug.Log (BallControl.positionState);

		//Debug.Log (score);

		if (playerBall.position.z < -8f && Input.GetMouseButtonDown(0)){
			resetPositions();
		}

		if (Input.GetKey("escape"))
			Application.Quit();
		}
}
