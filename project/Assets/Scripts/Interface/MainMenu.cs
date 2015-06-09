using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int fontSize = 20;

	bool paused = false;
	bool displayStat = false;
	bool displayMainMenu = false;
	
	
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.P) && !displayStat && !displayMainMenu) {
			
			if(!paused) {
				Pause();
			}
			else {
				UnPause();
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Escape) && !displayStat) {
			
			if(displayMainMenu) {
				Pause();
			
				displayMainMenu=false;
			}
			else {
				UnPause();
				
				displayMainMenu=true;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Tab) && !displayMainMenu) {
			if(displayStat)
				displayStat=false;
			else
				displayStat=true;
		}
	}
	
	void OnGUI() {
		if(paused) {		
			GUI.Box (new Rect ( 0, 0, Screen.width, 30), "Paused");
		}
		
		if(displayMainMenu) {
			GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
			
			GUI.Box (new Rect ( 0, 0, Screen.width, Screen.height), "Main Menu");
			
			if(GUI.Button (new Rect ( (Screen.width/2)-100,(Screen.height/2)-100, 200,60 ), "Resume"))
				UnPause();
				
			if(GUI.Button (new Rect ( (Screen.width/2)-100,(Screen.height/2)-30, 200,60 ), "Restart")) {				
				Application.LoadLevel("main");
				UnPause();
			}
			
			if(GUI.Button (new Rect ( (Screen.width/2)-100,(Screen.height/2)+40, 200,60 ), "Quit"))
				Application.Quit();
		}
		
		if(displayStat) {
			GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
			
			GUI.Box (new Rect ( 0, 0, Screen.width, Screen.height), "Statistics");
			
			GUI.Box (new Rect ( (Screen.width/2)-100,(Screen.height/2)-100, 200, 30), "Ant count : " + Statistics.getTotalAnt());
			GUI.Box (new Rect ( (Screen.width/2)-100,(Screen.height/2)-30, 200, 30), "Spider count : " + Statistics.getTotalSpider());
			GUI.Box (new Rect ( (Screen.width/2)-100,(Screen.height/2)+40, 200, 30), "Termite count : " + Statistics.getTotalTermite());
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
