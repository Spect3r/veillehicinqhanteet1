using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int fontSize = 20;

	bool paused = false;
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
		}
	}
	
	void OnGUI() {
		if(paused) {
			GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
			
			GUI.Box (new Rect ( 0, 0, Screen.width, Screen.height), "Paused");
			
			if(GUI.Button (new Rect ( (Screen.width/2)-100,(Screen.height/2)-100, 200,60 ), "Resume"))
				UnPause();
				
			if(GUI.Button (new Rect ( (Screen.width/2)-100,(Screen.height/2)-30, 200,60 ), "Restart")) {				
				Application.LoadLevel("main");
				UnPause();
			}
			
			if(GUI.Button (new Rect ( (Screen.width/2)-100,(Screen.height/2)+40, 200,60 ), "Quit"))
				Application.Quit();
		}
	}
	
	void Pause() {
		Time.timeScale = 0;
		paused = true;
	}
	void UnPause() {
		Time.timeScale = 1;
		paused = false;
	}
}
