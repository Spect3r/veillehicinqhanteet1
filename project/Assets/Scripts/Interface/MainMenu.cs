using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int fontSize = 20;

	bool paused = false;
	bool displayStat = false;
	bool displayMainMenu = false;
	
	
	bool simulationEnd = false;
	string winner = "";
	bool win = false;
	
	
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.P) && !displayStat && !displayMainMenu && !simulationEnd) {
			
			if(!paused) {
				Pause();
			}
			else {
				UnPause();
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Escape) && !displayStat) {
			
			if(displayMainMenu) {
				if(paused)
					UnPause();
			
				displayMainMenu=false;
			}
			else {
				if(!paused)
					Pause();
				
				displayMainMenu=true;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Tab) && !displayMainMenu) {
			if(displayStat)
				displayStat=false;
			else
				displayStat=true;
		}
		
		if(Statistics.getTotalTermite() == 0 && Statistics.getTotalSpider() == 0 && !simulationEnd) {
			simulationEnd = true;
			winner = "Ant";
		}
		if(Statistics.getTotalAnt() == 0 && Statistics.getTotalTermite() == 0 && !simulationEnd) {
			simulationEnd = true;
			winner = "Spider";
		}
		if(Statistics.getTotalAnt() == 0 && Statistics.getTotalSpider() == 0 && !simulationEnd) {
			simulationEnd = true;
			winner = "Termite";
		}
			
	}
	
	void OnGUI() {
		if(paused && !displayStat && !displayMainMenu && !simulationEnd) {		
			GUI.Box (new Rect ( 0, 0, Screen.width, 30), "Paused");
		}
		
		if(displayMainMenu) {
			GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
			
			GUI.Box (new Rect ( 0, 0, Screen.width, Screen.height), "Main Menu");
			
			if(GUI.Button (new Rect ( (Screen.width/2)-100,(Screen.height/2)-100, 200,60 ), "Resume")) {
				UnPause();
				displayMainMenu = false;
			}
				
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
		
		if(simulationEnd && !win) {
			Pause();
			
			GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
			
			GUI.Box (new Rect ( 0, 0, Screen.width, Screen.height), "End of Simulation");
			
			GUI.Box (new Rect ( (Screen.width/2)-100,(Screen.height/2)-30, 200, 30), "The winner is : "+winner);
			
			if(GUI.Button (new Rect ( (Screen.width/2)-100,(Screen.height/2)+40, 200,30 ), "Ok")) {
				keepRunning();
			}
		}
	}
	
	void keepRunning() {
		win = true;
		displayStat = false;			
		displayMainMenu = true;
	}
	
	void Pause() {
		Simulator.running = false;
		paused = true;
	}
	void UnPause() {
		Simulator.running = true;
		paused = false;
	}
}
