using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {
	
	/** Agent **/
	private static int nbAntWorker;
	private static int nbAntSoldier;
	
	private static int nbSpiderDigger;
	private static int nbSpiderWanderer;
	
	private static int nbTermiteWorker;
	private static int nbTermiteSoldier;
	
	void Awake() {
		nbAntWorker = 0;
		nbAntSoldier = 0;
		
		nbSpiderDigger = 0;
		nbSpiderWanderer = 0;
		
		nbTermiteWorker = 0;
		nbTermiteSoldier = 0;
	}
	
	
	public static void addInsect(string type) {
		if (type == "AntWorker")
			nbAntWorker++;
		else if (type == "AntSoldier")
			nbAntSoldier++;
			
		else if (type == "SpiderDigger")
			nbSpiderDigger++;
		else if (type == "SpiderWanderer")
			nbSpiderWanderer++;
			
		else if (type == "TermiteWorker")
			nbTermiteWorker++;
		else if (type == "TermiteSoldier")
			nbTermiteSoldier++;
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
		
		else if (type == "TermiteWorker")
			nbTermiteWorker--;
		else if (type == "TermiteSoldier")
			nbTermiteSoldier--;
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
	public static int getNbTermiteWorker() {
		return nbTermiteWorker;
	}
	public static int getNbTermiteSoldier() {
		return nbTermiteSoldier;
	}
	
	
	public static int getTotalAnt() {
		return nbAntWorker + nbAntSoldier;
	}	
	public static int getTotalSpider() {
		return nbSpiderDigger + nbSpiderWanderer;		
	}	
	public static int getTotalTermite() {
		return nbTermiteWorker + nbTermiteSoldier;		
	}

}
