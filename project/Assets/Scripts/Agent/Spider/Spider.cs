using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spider : Insect {

	public bool isEnemy(GameObject enemy){
		if (enemy.tag == "AntWorker" || enemy.tag == "AntSoldier" || enemy.tag == "TermiteWorker" || enemy.tag == "TermiteSoldier")
			return true;
		else
			return false;
	}
}
