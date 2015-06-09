using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {
	
	/** Agent **/
	private static int nbAntWorker = 0;
	private static int nbAntSoldier = 0;
	
	private static int nbSpiderDigger = 0;
	private static int nbSpiderWanderer = 0;
	
	
	public static void addInsect(string type) {
		if (type == "AntWorker")
			nbAntWorker++;
		else if (type == "AntSoldier")
			nbAntSoldier++;
		else if (type == "SpiderDigger")
			nbSpiderDigger++;
		else if (type == "SpiderWanderer")
			nbSpiderWanderer++;
	}
	
	public static void removeInsect(string type) {
		if (type == "AntWorker")
			nbAntWorker--;
		else if (type == "AntSoldier")
			nbAntSoldier--;
		else if (type == "SpiderDigger")
			nbSpiderDigger--;
		else if (type == "SpiderWanderer")
			nbSpiderWanderer--;
	}
	
	
	
	public static int getNbAntWorker() {
		return nbAntWorker;
	}
	public static int getNbAntSoldier() {
		return nbAntSoldier;
	}
	public static int getNbSpiderDigger() {
		return nbSpiderDigger;
	}
	public static int getNbSpiderWanderer() {
		return nbSpiderWanderer;
	}
	
	
	public static int getTotalAnt() {
		return nbAntWorker + nbAntSoldier;
	}
	
	public static int getTotalSpider() {
		return nbSpiderDigger + nbSpiderWanderer;		
	}

}
