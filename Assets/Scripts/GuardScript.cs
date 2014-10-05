using UnityEngine;
using System.Collections;

public class GuardScript : MonoBehaviour {

	bool selected = false;
	private Vector3 target;
	private float speed = 1f;

	// Use this for initialization
	void Start () {
		target = transform.position;
	}

	void OnCollisionEnter2D(Collision2D collider) {
		GameObject crowd = collider.gameObject;
		if (crowd.name == "CrowdYellow1") {
				CrowdScript script = (CrowdScript)crowd.GetComponent ("CrowdScript");
				if (script != null) {
					script.guardCatched = true;
				}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit2D hitm= Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hitm.collider != null && hitm.collider.gameObject.name.Contains("Guard")) {
				selected = true;
			}

			if (selected) {
				gameObject.transform.renderer.material.color = Color.blue;
			} else {
//				gameObject.transform.renderer.material.color = Color.clear;
			}

		}

		// Move to the position
		if (selected && Input.GetMouseButtonDown (0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
		}
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		
	}
	
}
