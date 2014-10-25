using UnityEngine;
using System.Collections;

public class CrowdScript : MonoBehaviour {

	public float speed = 0.001f;
	float moveX = 0f;
	float moveY = 0f;

	public float randomX = 0f;
	public float randomY = 0f;

	public bool guardCatched = false;

	const float BOUNDARIES = 3.0f;

//	private CounterOfCollidedCrowdsScript counterCollObjects;
	private int groupMembers = 0;

//	private bool isCollidedWithSomeone = false;

	Vector3 currentPosition;

	public string groupName { get; set;}

	// Use this for initialization
	void Start () {
		currentPosition = new Vector3 (Random.Range(BOUNDARIES, -BOUNDARIES), Random.Range(BOUNDARIES, -BOUNDARIES), transform.position.z);
		randomX = Random.Range(-0.01f, 0.01f);
		randomY = Random.Range(-0.01f, 0.01f);

	}

	private void changeDirectionIfGuardCatched() {
		if (guardCatched) {
			randomX = Random.Range(-0.01f, 0.01f);
			randomY = Random.Range(-0.01f, 0.01f);

            if (Mathf.Sign(randomX) == -1)
            {
				if (currentPosition.x - 0.1f > -BOUNDARIES) {
					currentPosition.x = currentPosition.x - 0.1f;
				}
               	
            }
            else
            {
				if (currentPosition.x + 0.1f < BOUNDARIES)
                	currentPosition.x = currentPosition.x + 0.1f;
            }

            if (Mathf.Sign(randomY) == -1)
            {
				if (currentPosition.y - 0.1f > -BOUNDARIES)
                	currentPosition.y = currentPosition.y - 0.1f;
            }
            else
            {
				if (currentPosition.y + 0.1f < BOUNDARIES)
                	currentPosition.y = currentPosition.y + 0.1f;
            }


			guardCatched = false;
			this.groupName = null;
//            counterScript.decreaseColidedNumber();
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
//        ProgressBarScript counterScript = (ProgressBarScript)GameObject.Find("Guard1").GetComponent("ProgressBarScript");
		crowdScript = (CrowdScript) collider.gameObject.GetComponent ("CrowdScript");
		if (crowdScript != null) {
			float randomCollidedObjectX = crowdScript.randomX;
			float randomCollidedObjectY = crowdScript.randomY;
			randomX = randomCollidedObjectX;
			randomY = randomCollidedObjectY;
			if (crowdScript.groupName != null) {
				if (this.groupName != null) {
					assignBiggerGroupName(crowdScript.groupName);
				} else {
					this.groupName = crowdScript.groupName;
				}

			} else {
				string randomGroupName = generateRandomGroupName();
				crowdScript.groupName = randomGroupName;
				this.groupName = randomGroupName;
			}
		}

		}

	void assignBiggerGroupName(string colliderGroupName) {
		GameObject [] crowds = GameObject.FindGameObjectsWithTag ("crowd");
		int colliderGroupNameNumber = 0;
		int currentObjectGroupNameNumber = 0;
		foreach (GameObject crowd in crowds) {
			CrowdScript script = (CrowdScript)crowd.GetComponent("CrowdScript");
			if (script.groupName != null && script.groupName.Equals(colliderGroupName)) {
				colliderGroupNameNumber++;
			} else {
				currentObjectGroupNameNumber++;
			}
		}
		
		if (colliderGroupNameNumber > currentObjectGroupNameNumber) {
			foreach (GameObject crowd in crowds) {
					CrowdScript script = (CrowdScript)crowd.GetComponent("CrowdScript");
					if (script.groupName != null && script.groupName.Equals(this.groupName)) {
						script.groupName = colliderGroupName;
					}
			
			}
		} else {
				foreach (GameObject crowd in crowds) {
					CrowdScript script = (CrowdScript)crowd.GetComponent("CrowdScript");
					if (script.groupName != null && script.groupName.Equals(colliderGroupName)) {
						script.groupName = this.groupName;
					}
					
				}
			}
	}
		

	string generateRandomGroupName() {
		var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
//		var stringChars = new char[8];
		string stringChars = "";
//		var random = new Random ();

		for (int i = 0; i < 8; i++) {
			int index = Random.Range(0, chars.Length);
			stringChars = stringChars + chars[index];
		}
		
		return stringChars.ToString();
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (this.groupName);
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
