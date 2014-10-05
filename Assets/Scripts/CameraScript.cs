using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float maxSpeed = 10f;
	Vector3 currentPosition;


	// Use this for initialization
	void Start () {
	
	}
	


	void FixedUpdate() {

		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		float deltaX = transform.position.x + moveX;
		float deltaY = transform.position.y + moveY;

		Vector3 positionToBe = new Vector3 (deltaX, deltaY, -10f);

		transform.position = positionToBe;


	}
}
