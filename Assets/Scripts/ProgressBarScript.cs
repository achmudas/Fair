using UnityEngine;
using System.Collections;

public class ProgressBarScript : MonoBehaviour {

	private float barDisplay; //current progress
	public Vector2 pos = new Vector2(73,400);
	public Vector2 size = new Vector2(700,40);
	private Texture2D emptyTex;
	private Texture2D fullTex;




	void Start() {
		emptyTex = (Texture2D) Resources.Load("EmptyProgressBar") as Texture2D;
		fullTex = (Texture2D) Resources.Load("FullProgressBar") as Texture2D;
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
	
	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever70070
		barDisplay = 0.5f;
		//      barDisplay = MyControlScript.staticHealth;
	}
}
