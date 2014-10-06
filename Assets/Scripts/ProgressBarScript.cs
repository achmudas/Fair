using UnityEngine;
using System.Collections;

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

    public void increaseColidedNumber() {
        countOfCollidedObjects++;
    }

    public void decreaseColidedNumber()
    {
        countOfCollidedObjects--;
    }

	void Update() {
        Debug.Log(countOfCollidedObjects);
        barDisplay = 0.0005f * countOfCollidedObjects;
		
	}
}
