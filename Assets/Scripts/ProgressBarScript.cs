using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressBarScript : MonoBehaviour {

	private float barDisplay; //current progress
    public Vector2 size = new Vector2(700, 40);
    private Vector2 pos;
   // private Vector2 pos = new Vector2(15, 20);

	private Texture2D emptyTex;
	private Texture2D fullTex;

    public int countOfCollidedObjects = 0;




	void Start() {
		emptyTex = (Texture2D) Resources.Load("EmptyProgressBar") as Texture2D;
		fullTex = (Texture2D) Resources.Load("FullProgressBar") as Texture2D;
        pos = new Vector2(Screen.width / 2 - size.x / 2, 20f);
	}

	void OnGUI() {

		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		Rect myRect = new Rect (0, 0, size.x, size.y);
	
		GUI.DrawTexture (myRect, emptyTex);	

//		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.DrawTexture(myRect, fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}

//    public void increaseColidedNumber() {
//        countOfCollidedObjects++;
//    }
//
//    public void decreaseColidedNumber()
//    {
//        countOfCollidedObjects--;
//    }

	void Update() {
		float multiplayer = 0f;
		GameObject [] crowds = GameObject.FindGameObjectsWithTag ("crowd");
		Dictionary<string, int> groupsWithNumberOfMembers = new Dictionary<string, int> ();

		foreach (GameObject crowd in crowds) {
			CrowdScript script = (CrowdScript)crowd.GetComponent("CrowdScript");
			if (script.groupName != null) {
//				Debug.Log(script.groupName);
				if (!groupsWithNumberOfMembers.ContainsKey(script.groupName)) {
					groupsWithNumberOfMembers.Add(script.groupName, 1);
					} else {
					int numberOfMembers = 0;
					groupsWithNumberOfMembers.TryGetValue(script.groupName, out numberOfMembers);
					numberOfMembers++;
					groupsWithNumberOfMembers[script.groupName] = numberOfMembers;
					}
			}



		}

		foreach (int groupSize in groupsWithNumberOfMembers.Values) {
//			Debug.Log(groupSize);
			if (groupSize > 2 && groupSize <= 4) {
				multiplayer = multiplayer + 0.2f;
//				Debug.Log("3: " + groupSize);
			} else if (groupSize > 4 && groupSize <= 6) {
				multiplayer = multiplayer + 0.4f;
//				Debug.Log("5: " + groupSize);
			}
			else if (groupSize > 6) {
				multiplayer = multiplayer + 0.6f;
			}
			else {
				multiplayer = multiplayer + 0.0f;
			}
		}


//        barDisplay = barDisplay + multiplayer;
		barDisplay = 0.05f * multiplayer;
	}
}
