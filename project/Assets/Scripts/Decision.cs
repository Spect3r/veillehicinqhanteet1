using UnityEngine;
using System.Collections;

public class Decision : MonoBehaviour {

	string myBehaviour;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void makeDecision(Insect tab){

		foreach(Insect i in tab){

			/* **** ANT **** */

			if (i.espece == "ant"){
				switch(i.behaviour){
					case "FindFood":
						i.findFood();
					break;
					case "GoToQueen":
						i.goToQueen();
					break;
//					case "RandomMove":
//						i.move();
//					break;
					default :
					throw new UnityException("Pas de comportement");
				}

			/* **** TERMITE **** */

			}else if(i.espece == "termite")
			{
				switch(i.behaviour){
					case "FindFood":
						i.findFood();
						break;
					case "GoToQueen":
						i.goToQueen();
					break;
	//					case "RandomMove":
	//						i.move();
	//					break;
					default :
					throw new UnityException("Pas de comportement");
				}

			}

			/* **** SPIDER **** */

			else if(i.espece == "spider")
			{
				switch(i.behaviour){
//					case "RandomMove":
//						i.move();
//					break;
//					case "Eat":
//						i.eatInsect();
//					break;
				default :
				throw new UnityException("Pas de comportement");
				}

			}

		}

	}
	

	// OU !!



	void makeDecision(){

		switch (this.myBehaviour) {
			case "FindFood":
				this.findFood();
				break;
			case "GoToQueen":
				this.goToQueen();
				break;
				//					case "RandomMove":
				//						i.move();
				//					break;
			default :
			throw new UnityException("Pas de comportement");

		}
	}
	*/
}
