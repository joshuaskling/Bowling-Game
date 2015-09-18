using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	protected Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (new Vector3 (0f, 0f, -100000f).normalized);
	}
}
