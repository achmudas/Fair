using UnityEngine;
using System.Collections;

public class CrowdScript : MonoBehaviour {

	public float speed = 0.001f;
	float moveX = 0f;
	float moveY = 0f;

	public float randomX = 0f;
	public float randomY = 0f;

	public bool guardCatched = false;

	const float BOUNDARIES = 3.2f;

//	private CounterOfCollidedCrowdsScript counterCollObjects;
	private int groupMembers = 0;

	Vector3 currentPosition;

	// Use this for initialization
	void Start () {
		currentPosition = new Vector3 (Random.Range(BOUNDARIES, -BOUNDARIES), Random.Range(BOUNDARIES, -BOUNDARIES), transform.position.z);
		randomX = Random.Range(-0.01f, 0.01f);
		randomY = Random.Range(-0.01f, 0.01f);

        //counterCollObjects = GameObject.Find("Guard1").GetComponent("CounterOfCollidedCrowds");

	}

	private void changeDirectionIfGuardCatched() {
		if (guardCatched) {
			randomX = Random.Range(-0.01f, 0.01f);
			randomY = Random.Range(-0.01f, 0.01f);
			guardCatched = false;
            ProgressBarScript counterScript = (ProgressBarScript)GameObject.Find("Guard1").GetComponent("ProgressBarScript");
            counterScript.decreaseColidedNumber();
		}
	}

	void FixedUpdate() {
		changeDirectionIfGuardCatched ();
		ChangeDirectionIfHitsBoundaries ();

		moveX = currentPosition.x + (speed * randomX);
		moveY = currentPosition.y + (speed * randomY);

		Vector3 moveToPosition = new Vector3 (moveX, moveY, 0f);
		transform.position = moveToPosition;

		currentPosition = moveToPosition;
	}

	void OnCollisionEnter2D(Collision2D collider) {
        CrowdScript crowdScript;
        ProgressBarScript counterScript = (ProgressBarScript)GameObject.Find("Guard1").GetComponent("ProgressBarScript");
		crowdScript = (CrowdScript) collider.gameObject.GetComponent ("CrowdScript");
		if (crowdScript != null) {
			float randomCollidedObjectX = crowdScript.randomX;
			float randomCollidedObjectY = crowdScript.randomY;
			randomX = randomCollidedObjectX;
			randomY = randomCollidedObjectY;
            counterScript.increaseColidedNumber();
		}

		}

	// Update is called once per frame
	void Update () {
	}

	void ChangeDirectionIfHitsBoundaries ()
	{
		if (currentPosition.x > BOUNDARIES || currentPosition.x < -BOUNDARIES) {
			randomX = randomX * -1;
		}
		if (currentPosition.y > BOUNDARIES || currentPosition.y < -BOUNDARIES) {
			randomY = randomY * -1;
		}
	}
}
