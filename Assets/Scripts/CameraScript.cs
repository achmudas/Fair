using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

//	public float maxSpeed = 10f;
	Vector3 currentPosition;



	// Use this for initialization
	void Start () {
		currentPosition.z = -20f;
	}
	


	void FixedUpdate() {
		Vector3 playerPosition = GameObject.Find ("Guard1").transform.position;
		if (playerPosition.x > -0.5f && playerPosition.x < 0.5f) {
			currentPosition.x = playerPosition.x;
		}

		if (playerPosition.y > -1.5f && playerPosition.y < 1.5f) {
						currentPosition.y = playerPosition.y;
				}

		gameObject.transform.position = currentPosition;
	}
}
