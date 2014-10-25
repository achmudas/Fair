using UnityEngine;
using System.Collections;

public class GuardScript : MonoBehaviour {

	bool selected = false;
	private Vector3 target;
    
    const float BOUNDARIES = 2.9f;

    private float maxSpeed = 0.1f;
    Vector3 currentPosition;

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

    void FixedUpdate()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if ((transform.position.x <= BOUNDARIES && transform.position.x >= -BOUNDARIES) && (transform.position.y <= BOUNDARIES && transform.position.y >= -BOUNDARIES))
        {

            float deltaX = transform.position.x + (maxSpeed * moveX);
            float deltaY = transform.position.y + (maxSpeed * moveY);

            checkIfBoundaries(ref deltaX, ref deltaY);

            Vector3 positionToBe = new Vector3(deltaX, deltaY, 4f);
            transform.position = positionToBe;
        }
       
            
    }

    private static void checkIfBoundaries(ref float deltaX, ref float deltaY)
    {
        if (deltaX > BOUNDARIES)
        {
            deltaX = BOUNDARIES;
        }
        if (deltaX < -BOUNDARIES)
        {
            deltaX = -BOUNDARIES;
        }
        if (deltaY > BOUNDARIES)
        {
            deltaY = BOUNDARIES;
        }
        if (deltaY < -BOUNDARIES)
        {
            deltaY = -BOUNDARIES;
        }
    }
	
	// Update is called once per frame
	void Update () {

//        if (Input.GetMouseButtonDown(0)) {
//            RaycastHit2D hitm= Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

//            if (hitm.collider != null && hitm.collider.gameObject.name.Contains("Guard")) {
//                selected = true;
//            }

//            if (selected) {
//                gameObject.transform.renderer.material.color = Color.blue;
//            } else {
////				gameObject.transform.renderer.material.color = Color.clear;
//            }

//        }

//        // Move to the position
//        if (selected && Input.GetMouseButtonDown (0)) {
//            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            target.z = transform.position.z;
//        }
//        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		
	}
	
}
